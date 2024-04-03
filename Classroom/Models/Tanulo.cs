using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.Models
{
    public class Tanulo
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Email { get; set; }
        public int? KurzusId { get; set; }
        public Kurzus Kurzus { get; set; }
    }
}
