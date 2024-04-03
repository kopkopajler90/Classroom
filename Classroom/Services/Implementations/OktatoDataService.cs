using Classroom.Models;
using Classroom.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.Services.Implementations
{
    public class OktatoDataService : IOktatoDataService
    {
        private readonly ClassroomContext _context;
        public OktatoDataService(ClassroomContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public async Task<Oktato> CreateAsync(Oktato oktato)
        {
            if(oktato != null)
            {
                await _context.Oktatok.AddAsync(oktato);
                await _context.SaveChangesAsync();
                return oktato;
            }
            throw new Exception("Nem sikerült az oktató létrehozása!");
        }

        public async Task DeleteAsync(int id)
        {
            var oktato = await _context.Oktatok.FindAsync(id);
            if (oktato != null)
            {
                _context.Oktatok.Remove(oktato);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<Oktato>> GetAllAsync()
        {
            var oktatok = await _context.Oktatok.ToListAsync();
            if (oktatok != null)
            {
                return oktatok;
            }
            throw new Exception("Nincs oktató az adatbázisban!");
        }

        public async Task<Oktato> GetByIdAsync(int id)
        {
            var oktato = await _context.Oktatok.FindAsync(id);
            if (oktato != null)
            {
                return oktato;
            }
            throw new Exception("Nincs oktató az adatbázisban!");
        }

        public async Task UpdateAsync(Oktato oktato)
        {
            if(oktato != null)
            {
                _context.Oktatok.Update(oktato);
                await _context.SaveChangesAsync();
            }
            throw new Exception("Nem sikerült az oktató frissítése!");
        }
    }
}
