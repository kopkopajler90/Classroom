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
    internal class KurzusDataService : IKurzusDataService
    {
        public event Action? ChangesSaved;
        private readonly ClassroomContext _context;

        public KurzusDataService(ClassroomContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        public async Task<Kurzus> CreateAsync(Kurzus kurzus)
        {
            if(kurzus != null)
            {
                await _context.Kurzusok.AddAsync(kurzus);
                await _context.SaveChangesAsync();
                ChangesSaved?.Invoke();
                return kurzus;
            }
            throw new Exception("Nem sikerült a kurzus létrehozása!");
        }

        public async Task DeleteAsync(int id)
        {
            var kurzus = await _context.Kurzusok.FirstOrDefaultAsync(k => k.Id == id);
            if (kurzus != null)
            {
                _context.Kurzusok.Remove(kurzus);
                await _context.SaveChangesAsync();
                ChangesSaved?.Invoke();
            }
            throw new Exception("Nem sikerült a kurzus törlése!");
        }

        public async Task<IEnumerable<Kurzus>> GetAllAsync()
        {
            var kurzusok = await _context.Kurzusok.ToListAsync();
            if (kurzusok != null)
            {
                return  kurzusok;
            }
            throw new Exception("Nincs kurzus az adatbázisban!");
        }

        public async Task<Kurzus> GetByIdAsync(int id)
        {
            var kurzus = await _context.Kurzusok.FirstOrDefaultAsync(k => k.Id == id);
            if (kurzus != null)
            {
                return kurzus;
            }
            throw new Exception("Nincs kurzus az adatbázisban!");
        }

        public async Task<IEnumerable<Kurzus>> GetByOktatoIdAsync(int oktatoId)
        {
            var kurzusok = await _context.Kurzusok.Where(k => k.OktatoId == oktatoId).ToListAsync();
            if (kurzusok != null)
            {
                return kurzusok;
            }
            throw new Exception("Nincs kurzus az adatbázisban!");
        }

        public async Task<Kurzus> GetByTanuloIdAsync(int tanuloId)
        {
            var kurzus = await _context.Kurzusok.FirstOrDefaultAsync(k => k.Id == tanuloId);
            if (kurzus != null)
            {
                return kurzus;
            }
            throw new Exception("Nincs kurzus az adatbázisban!");
        }

        public async Task UpdateAsync(Kurzus kurzus)
        {
            throw new NotImplementedException();
        }
    }
}
