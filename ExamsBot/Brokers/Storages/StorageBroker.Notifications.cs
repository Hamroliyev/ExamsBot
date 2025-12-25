// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using ExamsBot.Models.Notifications;
using Microsoft.EntityFrameworkCore;

namespace ExamsBot.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Notification> Notifications { get; set; }
        public async ValueTask<Notification> InsertNotificationAsync(Notification notification) =>
            await InsertAsync(notification);
        public IQueryable<Notification> SelectAllNotifications() => 
            SelectAll<Notification>();
        public async ValueTask<Notification> SelectNotificationByIdAsync(Guid id) =>
            await SelectAsync<Notification>(id);
        public async ValueTask<Notification> UpdateNotificationAsync(Notification notification) =>
            await UpdateAsync(notification);
        public async ValueTask<Notification> DeleteNotificationAsync(Notification notification) =>
            await DeleteAsync(notification);
    }
}
