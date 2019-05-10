using dotnetforum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dotnetforum.BLL.Services
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserAsync(int userId);

        Task<IEnumerable<ApplicationUser>> GetUsersAsync();

        Task<ApplicationUser> InsertUserAsync(ApplicationUser newUser);

        Task UpdateUserAsync(int userId, ApplicationUser updatedUser);

        Task DeleteUserAsync(int userId);
    }
}
