using Classroom.Models;
using Classroom.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.Services.Implementations
{
    internal class TanuloDataService : ITanuloDataService

    {
        private readonly ClassroomContext _context;
        public TanuloDataService(ClassroomContext context)
        {
            _context = context;
         
            

        }
        public async Task<Tanulo> CreateAsync(Tanulo tanulo)
        {
           if(tanulo != null)
            {
                await _context.Tanulok.AddAsync(tanulo);
                await _context.SaveChangesAsync();
                return tanulo;
            }
            throw new Exception("Nem sikerült a tanuló létrehozása!");

        }

        public async Task DeleteAsync(int id)
        {
            var tanulo = await _context.Tanulok.FirstOrDefaultAsync(t => t.Id == id);
            if (tanulo != null)
            {
                _context.Tanulok.Remove(tanulo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Tanulo>> GetAllAsync()
        {
            var tanulok = await _context.Tanulok.ToListAsync();
            if (tanulok != null)
            {
                return tanulok;
            }
            throw new Exception("Nincs tanuló az adatbázisban!");
        }

        public async Task<Tanulo> GetByIdAsync(int id)
        {
            var tanulo = await _context.Tanulok.FirstOrDefaultAsync(t => t.Id == id);
            if (tanulo != null)
            {
                return tanulo;
            }
            throw new Exception("Nincs tanuló az adatbázisban!");
        }

        public async Task UpdateAsync(Tanulo tanulo)
        {
            throw new NotImplementedException();
        }
    }
}
