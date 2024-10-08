using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace Blogs.API.Brokers.UserManagements
{
    public class UserManagementBroker : IUserManagementBroker
    {
        private readonly UserManager<User> userManagement;

        public UserManagementBroker(UserManager<User> userManagement)
        {
            this.userManagement = userManagement;
        }

        public IQueryable<User> SelectAllUsers() => this.userManagement.Users;

        public async ValueTask<User> SelectUserByIdAsync(Guid userId)
        {
            var broker = new UserManagementBroker(this.userManagement);

            return await broker.userManagement.FindByIdAsync(userId.ToString());
        }

        public async ValueTask<User> InsertUserAsync(User user, string password)
        {
            var broker = new UserManagementBroker(this.userManagement);
            await broker.userManagement.CreateAsync(user, password);

            return user;
        }

        public async ValueTask<User> UpdateUserAsync(User user)
        {
            var broker = new UserManagementBroker(this.userManagement);
            await broker.userManagement.UpdateAsync(user);

            return user;
        }

        public async ValueTask<User> DeleteUserAsync(User user)
        {
            var broker = new UserManagementBroker(this.userManagement);
            await broker.userManagement.DeleteAsync(user);

            return user;
        }
    }
}