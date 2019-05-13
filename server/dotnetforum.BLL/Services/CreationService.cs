using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dotnetforum.BLL.Exceptions;
using dotnetforum.DAL;
using dotnetforum.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotnetforum.BLL.Services
{
    public class CreationService : ICreationService
    {
        private readonly Context context;

        public CreationService(Context context)
        {
            this.context = context;
        }


        public async Task<Creation> GetCreationAsync(int creationId)
        {
            return await context.Creations
                .Include(c => c.Reviews)
                    .SingleOrDefaultAsync(c => c.Id == creationId) ?? throw new EntityNotFoundException("The creation could not be found");
        }

        public async Task<IEnumerable<Creation>> GetCreationsAsync()
        {
            var creations = await context.Creations
               .Include(c => c.Reviews)
               .ToListAsync();

            return creations;
        }
    }
}
