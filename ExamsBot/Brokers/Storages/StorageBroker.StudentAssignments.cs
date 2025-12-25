// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using ExamsBot.Models.Assignments;
using Microsoft.EntityFrameworkCore;

namespace ExamsBot.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<StudentAssignment> StudentAssignments { get; set; }
        public async ValueTask<StudentAssignment> InsertStudentAssignmentAsync(StudentAssignment studentAssignment) =>
            await InsertAsync(studentAssignment);
        public IQueryable<StudentAssignment> SelectAllStudentAssignments() =>
            SelectAll<StudentAssignment>();
        public async ValueTask<StudentAssignment> SelectStudentAssignmentByIdAsync(Guid id) =>
            await SelectAsync<StudentAssignment>(id);
        public async ValueTask<StudentAssignment> UpdateStudentAssignmentAsync(StudentAssignment studentAssignment) =>
            await UpdateAsync(studentAssignment);
        public async ValueTask<StudentAssignment> DeleteStudentAssignmentAsync(StudentAssignment studentAssignment) =>
            await DeleteAsync(studentAssignment);
    }
}
