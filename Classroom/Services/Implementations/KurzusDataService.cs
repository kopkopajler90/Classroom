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

        public Task<Kurzus> CreateAsync(Kurzus kurzus)
        {
            if (kurzus != null)
            {
                _context.Kurzusok.Add(kurzus);
                _context.SaveChanges();
                ChangesSaved?.Invoke();
                return Task.FromResult(kurzus);
            }
            throw new Exception("Nem sikerült a kurzus létrehozása!");
        }

        public Task DeleteAsync(int id)
        {
            var kurzus = _context.Kurzusok.FirstOrDefault(k => k.Id == id);
            if (kurzus != null)
            {
                _context.Kurzusok.Remove(kurzus);
                _context.SaveChanges();
                ChangesSaved?.Invoke();
            }
            else
            {
                throw new Exception("Nem sikerült a kurzus törlése!");
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Kurzus>> GetAllAsync()
        {
            var kurzusok = _context.Kurzusok.ToList();
            if (kurzusok != null)
            {
                return Task.FromResult(kurzusok.AsEnumerable());
            }
            throw new Exception("Nincs kurzus az adatbázisban!");
        }

        public Task<Kurzus> GetByIdAsync(int id)
        {
            var kurzus = _context.Kurzusok.FirstOrDefault(k => k.Id == id);
            if (kurzus != null)
            {
                return Task.FromResult(kurzus);
            }
            throw new Exception("Nincs kurzus az adatbázisban!");
        }

        public Task<IEnumerable<Kurzus>> GetByOktatoIdAsync(int oktatoId)
        {
            var kurzusok = _context.Kurzusok.Where(k => k.OktatoId == oktatoId).ToList();
            if (kurzusok != null)
            {
                return Task.FromResult(kurzusok.AsEnumerable());
            }
            throw new Exception("Nincs kurzus az adatbázisban!");
        }

        public Task<Kurzus> GetByTanuloIdAsync(int tanuloId)
        {
            var kurzus = _context.Kurzusok.FirstOrDefault(k => k.Id == tanuloId);
            if (kurzus != null)
            {
                return Task.FromResult(kurzus);
            }
            throw new Exception("Nincs kurzus az adatbázisban!");
        }

        public Task UpdateAsync(Kurzus kurzus)
        {
            throw new NotImplementedException();
        }
    }
}