// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ExamsBot.Models.Admin;

namespace ExamsBot.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<AdminLog> AdminLogs { get; set; }
        public async ValueTask<AdminLog> InsertAdminLogAsync(AdminLog adminLog) =>
            await InsertAsync(adminLog);
        public IQueryable<AdminLog> SelectAllAdminLogs() =>
            SelectAll<AdminLog>();
        public async ValueTask<AdminLog> SelectAdminLogByIdAsync(Guid id) =>
            await SelectAsync<AdminLog>(id);
    }
}
