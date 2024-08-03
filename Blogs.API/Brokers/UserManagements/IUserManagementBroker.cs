using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogs.API.Models.Users;

namespace Blogs.API.Brokers.UserManagements
{
    public interface IUserManagementBroker
    {
        ValueTask<User> InsertUserAsync(User user, string password);
        IQueryable<User> SelectAllUsers();
        ValueTask<User> SelectUserByIdAsync(Guid userId);
        ValueTask<User> UpdateUserAsync(User user);
        ValueTask<User> DeleteUserAsync(User user);
    }
}