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

        public Task<Tanulo> CreateAsync(Tanulo tanulo)
        {
            if (tanulo != null)
            {
                _context.Tanulok.Add(tanulo);
                _context.SaveChanges();
                return Task.FromResult(tanulo);
            }
            throw new Exception("Nem sikerült a tanuló létrehozása!");
        }

        public Task DeleteAsync(int id)
        {
            var tanulo = _context.Tanulok.FirstOrDefault(t => t.Id == id);
            if (tanulo != null)
            {
                _context.Tanulok.Remove(tanulo);
                _context.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Tanulo>> GetAllAsync()
        {
            var tanulok = _context.Tanulok.ToList();
            if (tanulok != null)
            {
                return Task.FromResult(tanulok.AsEnumerable());
            }
            throw new Exception("Nincs tanuló az adatbázisban!");
        }

        public Task<Tanulo> GetByIdAsync(int id)
        {
            var tanulo = _context.Tanulok.Find(id);
            if (tanulo != null)
            {
                return Task.FromResult(tanulo);
            }
            throw new Exception("Nincs tanuló az adatbázisban!");
        }

        public Task UpdateAsync(Tanulo tanulo)
        {
            throw new NotImplementedException();
        }
    }
}