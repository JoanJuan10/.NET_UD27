using System;
using System.Collections.Generic;

namespace EX2.Models
{
    public partial class Cientifico
    {
        public Cientifico()
        {
            CientificoAsignadoA = new HashSet<Asignado>();
        }

        public string DNI { get; set; }
        public string NomApels { get; set; }

        public virtual ICollection<Asignado> CientificoAsignadoA { get; set; }

    }
}
