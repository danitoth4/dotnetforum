﻿using dotnetforum.BLL.Exceptions;
using dotnetforum.DAL;
using dotnetforum.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dotnetforum.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly Context context;

        public UserService(Context context)
        {
            this.context = context;
        }

        public async Task<ApplicationUser> GetUserAsync(int userId)
        {
            return await context.Users
                .Include(u => u.Comments)
                .Include(u => u.Reviews)
                    .SingleOrDefaultAsync(u => u.Id == userId) ?? throw new EntityNotFoundException("The user could not be found");
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync()
        {
            var users = await context.Users
                .Include(u => u.Comments)
                .Include(u => u.Reviews)
                    .ToListAsync();

            return users;
        }

        public async Task<ApplicationUser> InsertUserAsync(ApplicationUser newUser)
        {
            context.Users.Add(newUser);

            await context.SaveChangesAsync();

            return newUser;
        }

        public async Task UpdateUserAsync(int userId, ApplicationUser updatedUser)
        {
            updatedUser.Id = userId;
            var entry = context.Attach(updatedUser);
            entry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            context.Users.Remove(new ApplicationUser { Id = userId });

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new EntityNotFoundException("The user could not be found");
            }
        }
    }
}
