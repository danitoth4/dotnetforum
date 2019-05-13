using dotnetforum.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dotnetforum.BLL.Services
{
    public interface ICreationService
    {
        Task<Creation> GetCreationAsync(int creationId);

        Task<IEnumerable<Creation>> GetCreationsAsync();

        //Task<Creation> InsertCreationAsync(Creation newCreation);

        //Task UpdateCreationAsync(int creationId, Creation updatedCreation);

        //Task DeleteCreationAsync(int creationId);
    }
}
