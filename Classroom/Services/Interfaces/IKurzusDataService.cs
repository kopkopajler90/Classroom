using Classroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.Services.Interfaces
{
    public interface IKurzusDataService
    {
        Task<IEnumerable<Kurzus>> GetAllAsync();
        Task<Kurzus> GetByIdAsync(int id);
        Task<Kurzus> CreateAsync(Kurzus kurzus);
        Task UpdateAsync(Kurzus kurzus);
        Task DeleteAsync(int id);
        Task<IEnumerable<Kurzus>> GetByOktatoIdAsync(int oktatoId);
        Task<Kurzus> GetByTanuloIdAsync(int tanuloId);
    }
}
