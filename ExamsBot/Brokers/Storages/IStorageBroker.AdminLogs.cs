// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using ExamsBot.Models.Admin;

namespace ExamsBot.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<AdminLog> InsertAdminLogAsync(AdminLog adminLog);
        IQueryable<AdminLog> SelectAllAdminLogs();
        ValueTask<AdminLog> SelectAdminLogByIdAsync(Guid id);
    }
}
