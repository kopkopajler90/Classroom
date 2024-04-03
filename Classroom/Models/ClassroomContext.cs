using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.Models
{
    public class ClassroomContext : DbContext
    {
        private readonly string connStrRemote = ConfigurationManager.ConnectionStrings["connStrRemote"].ConnectionString;

        public ClassroomContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Oktato> Oktatok { get; set; }
        public DbSet<Tanulo> Tanulok { get; set; }
        public DbSet<Kurzus> Kurzusok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connStrRemote, ServerVersion.AutoDetect(connStrRemote));
        }
    }
}
