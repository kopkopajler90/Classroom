using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classroom.Models
{
    public class Oktato
    {
        public int Id { get; set; }

        public string Vnev { get; set; }

        public string Knev { get; set; }

        public virtual ICollection<Kurzus> Kurzusok { get; set; }



    }
}
