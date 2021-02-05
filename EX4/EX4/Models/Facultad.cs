using System;
using System.Collections.Generic;

namespace EX4.Models
{
    public partial class Facultad
    {
        public Facultad()
        {
            Equipos = new HashSet<Equipo>();
            Investigadores = new HashSet<Investigador>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Equipo> Equipos { get; set; }
        public virtual ICollection<Investigador> Investigadores { get; set; }

    }
}
