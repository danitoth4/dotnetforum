using dotnetforum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dotnetforum.BLL.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int userId);

        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> InsertUserAsync(User newUser);

        Task UpdateUserAsync(int userId, User updatedUser);

        Task DeleteUserAsync(int userId);
    }
}
