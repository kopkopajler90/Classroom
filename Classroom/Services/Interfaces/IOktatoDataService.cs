using Classroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.Services.Interfaces
{
    public interface IOktatoDataService
    {
        Task<IEnumerable<Oktato>> GetAllAsync();
        Task<Oktato> GetByIdAsync(int id);
        Task<Oktato> CreateAsync(Oktato oktato);
        Task UpdateAsync(Oktato oktato);
        Task DeleteAsync(int id);
    }
}
