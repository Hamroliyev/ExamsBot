// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using ExamsBot.Models.Notifications;

namespace ExamsBot.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Notification> InsertNotificationAsync(Notification notification);
        IQueryable<Notification> SelectAllNotifications();
        ValueTask<Notification> SelectNotificationByIdAsync(Guid id);
        ValueTask<Notification> UpdateNotificationAsync(Notification notification);
        ValueTask<Notification> DeleteNotificationAsync(Notification notification);
    }
}
