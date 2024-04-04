using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.Models
{
    public class Kurzus
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public int OktatoId { get; set; }
        public Oktato Oktato { get; set; }
        public DateTime Kezdet { get; set; }
        public DateTime Vege { get; set; }
        public ICollection<Tanulo> Tanulok { get; set; }
    }
}
