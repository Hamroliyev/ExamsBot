// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using ExamsBot.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace ExamsBot.Brokers.UserManagement
{
    public class UserManagementBroker : IUserManagementBroker
    {
        private readonly UserManager<User> userManagement;

        public UserManagementBroker(UserManager<User> userManager)
        {
            this.userManagement = userManager;
        }
        public IQueryable<User> SelectAllUsers() => this.userManagement.Users;

        public async ValueTask<User> SelectUserByIdAsync(Guid userId) =>
            await this.userManagement.FindByIdAsync(userId.ToString());

        public async ValueTask<User> InsertUserAsync(User user, string password)
        {
            await this.userManagement.CreateAsync(user, password);

            return user;
        }

        public async ValueTask<User> UpdateUserAsync(User user)
        {
            await this.userManagement.UpdateAsync(user);

            return user;
        }

        public async ValueTask<User> DeleteUserAsync(User user)
        {
            await this.userManagement.DeleteAsync(user);

            return user;
        }
    }
}
