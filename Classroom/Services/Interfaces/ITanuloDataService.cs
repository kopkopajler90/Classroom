using Classroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.Services.Interfaces
{
    public interface ITanuloDataService:ICommonDataService
    {
        Task<IEnumerable<Tanulo>> GetAllAsync();
        Task<Tanulo> GetByIdAsync(int id);
        Task<Tanulo> CreateAsync(Tanulo tanulo);
        Task UpdateAsync(Tanulo tanulo);
        Task DeleteAsync(int id);
    }
}
