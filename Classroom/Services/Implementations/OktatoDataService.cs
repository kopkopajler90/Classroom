using Classroom.Models;
using Classroom.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.Services.Implementations
{
    internal class OktatoDataService : IOktatoDataService
    {
        public Task<Oktato> CreateAsync(Oktato oktato)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Oktato>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Oktato> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Oktato oktato)
        {
            throw new NotImplementedException();
        }
    }
}
