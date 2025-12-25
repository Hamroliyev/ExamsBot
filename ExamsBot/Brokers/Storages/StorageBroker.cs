// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using EFxceptions;
using ExamsBot.Models.Admin;
using ExamsBot.Models.Assignments;
using ExamsBot.Models.Exams;
using ExamsBot.Models.Notifications;
using ExamsBot.Models.TelegramUserMessages;
using ExamsBot.Models.Results;
using ExamsBot.Models.TelegramUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExamsBot.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }
        public async ValueTask<T> InsertAsync<T>(T @object) where T : class
        {
            this.Entry(@object).State = EntityState.Added;
            await this.SaveChangesAsync();

            return @object;
        }

        public IQueryable<T> SelectAll<T>() where T : class
        {
            return this.Set<T>();
        }

        public async ValueTask<T> SelectAsync<T>(params object[] @objectIds) where T : class
        {
            return await this.FindAsync<T>(@objectIds);
        }

        public async ValueTask<T> UpdateAsync<T>(T @object) where T : class
        {
            this.Entry(@object).State = EntityState.Modified;
            await this.SaveChangesAsync();

            return @object;
        }

        public async ValueTask<T> DeleteAsync<T>(T @object) where T : class
        {
            this.Entry(@object).State = EntityState.Deleted;
            await this.SaveChangesAsync();

            return @object;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = this.configuration
                .GetConnectionString("DefaultConnection");

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AddTelegramUserConfigurations(modelBuilder);
            AddExamConfigurations(modelBuilder);
            AddStudentAssignmentConfigurations(modelBuilder);
            AddResultConfigurations(modelBuilder);
            AddTelegramUserMessageConfigurations(modelBuilder);
            AddNotificationConfigurations(modelBuilder);
            AddAdminLogConfigurations(modelBuilder);
        }

        private static void AddTelegramUserConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TelegramUser>(entity =>
            {
                entity.HasKey(u => u.Id);

                entity.HasIndex(u => u.TelegramId)
                    .IsUnique();

                entity.Property(u => u.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(u => u.LastName)
                    .HasMaxLength(100);

                entity.Property(u => u.Username)
                    .HasMaxLength(50);

                entity.Property(u => u.PhoneNumber)
                    .HasMaxLength(20);

                entity.HasMany(u => u.CreatedExams)
                    .WithOne(e => e.Teacher)
                    .HasForeignKey(e => e.CreatedByTeacherId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.Assignments)
                    .WithOne(a => a.Student)
                    .HasForeignKey(a => a.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.Results)
                    .WithOne(result => result.Student)
                    .HasForeignKey(result => result.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.Messages)
                    .WithOne(m => m.TelegramUser)
                    .HasForeignKey(m => m.TelegramUserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void AddExamConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>(entity =>
            {
                entity.HasKey(e => e.ExamId);

                entity.HasIndex(e => e.Status);
                entity.HasIndex(e => e.CreatedByTeacherId);

                entity.Property(e => e.ExamName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000);

                entity.Property(e => e.CorrectAnswers)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.AverageScore)
                    .HasPrecision(5, 2);

                entity.HasMany(e => e.Assignments)
                    .WithOne(a => a.Exam)
                    .HasForeignKey(a => a.ExamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.Results)
                    .WithOne(result => result.Exam)
                    .HasForeignKey(result => result.ExamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void AddStudentAssignmentConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentAssignment>(entity =>
            {
                entity.HasKey(a => a.AssignmentId);

                entity.HasIndex(a => a.StudentId);
                entity.HasIndex(a => a.ExamId);
                entity.HasIndex(a => a.Status);

                entity.HasIndex(a => new { a.StudentId, a.ExamId })
                    .IsUnique();

                entity.Property(a => a.TeacherNotes)
                    .HasMaxLength(500);

                entity.HasOne(a => a.Result)
                    .WithOne(result => result.Assignment)
                    .HasForeignKey<Result>(result => result.AssignmentId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.AssignedByTeacher)
                    .WithMany()
                    .HasForeignKey(a => a.AssignedByTeacherId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private static void AddResultConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasKey(result => result.ResultId);

                entity.HasIndex(result => result.StudentId);
                entity.HasIndex(result => result.ExamId);
                entity.HasIndex(result => result.AssignmentId).IsUnique();
                entity.HasIndex(result => result.Status);

                entity.Property(result => result.StudentAnswers)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(result => result.ScorePercentage)
                    .HasPrecision(5, 2);

                entity.Property(result => result.Grade)
                    .HasMaxLength(5);

                entity.Property(result => result.AnswerDetails)
                    .HasMaxLength(2000);

                entity.Property(result => result.TeacherComment)
                    .HasMaxLength(1000);

                entity.HasOne(result => result.CommentedByTeacher)
                    .WithMany()
                    .HasForeignKey(result => result.CommentedByTeacherId)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }

        private static void AddTelegramUserMessageConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TelegramUserMessage>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.HasIndex(m => m.TelegramUserId);
                entity.HasIndex(m => m.CreatedDate);
                entity.HasIndex(m => m.IsProcessed);

                entity.Property(m => m.MessageText)
                    .HasMaxLength(4096);

                entity.Property(m => m.ProcessingStatus)
                    .HasMaxLength(200);

                entity.Property(m => m.ErrorMessage)
                    .HasMaxLength(1000);

                entity.Property(m => m.Context)
                    .HasMaxLength(100);
            });
        }

        private static void AddNotificationConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(n => n.Id);

                entity.HasIndex(n => n.RecipientId);
                entity.HasIndex(n => n.IsSent);
                entity.HasIndex(n => n.Type);

                entity.Property(n => n.Message)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(n => n.ErrorMessage)
                    .HasMaxLength(500);

                entity.HasOne(n => n.Recipient)
                    .WithMany()
                    .HasForeignKey(n => n.RecipientId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private static void AddAdminLogConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminLog>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasIndex(a => a.AdminId);
                entity.HasIndex(a => a.Action);
                entity.HasIndex(a => a.CreatedAt);

                entity.Property(a => a.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(a => a.Details)
                    .HasMaxLength(2000);

                entity.HasOne(a => a.Admin)
                    .WithMany()
                    .HasForeignKey(a => a.AdminId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public override void Dispose() { }
    }
}