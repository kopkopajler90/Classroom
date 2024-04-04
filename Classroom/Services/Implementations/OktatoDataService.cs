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
        }

        public Task<Oktato> CreateAsync(Oktato oktato)
        {
            if (oktato != null)
            {
                _context.Oktatok.Add(oktato);
                _context.SaveChanges();
                return Task.FromResult(oktato);
            }
            throw new Exception("Nem sikerült az oktató létrehozása!");
        }

        public Task DeleteAsync(int id)
        {
            var oktato = _context.Oktatok.Find(id);
            if (oktato != null)
            {
                _context.Oktatok.Remove(oktato);
                _context.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Oktato>> GetAllAsync()
        {
            var oktatok = _context.Oktatok.ToList();
            if (oktatok != null)
            {
                return Task.FromResult(oktatok.AsEnumerable());
            }
            throw new Exception("Nincs oktató az adatbázisban!");
        }

        public Task<Oktato> GetByIdAsync(int id)
        {
            var oktato = _context.Oktatok.Find(id);
            if (oktato != null)
            {
                return Task.FromResult(oktato);
            }
            throw new Exception("Nincs oktató az adatbázisban!");
        }

        public Task UpdateAsync(Oktato oktato)
        {
            if (oktato != null)
            {
                _context.Oktatok.Update(oktato);
                _context.SaveChanges();
                return Task.CompletedTask;
            }
            throw new Exception("Nem sikerült az oktató frissítése!");
        }
    }
}