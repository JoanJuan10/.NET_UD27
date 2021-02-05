using System;
using System.Collections.Generic;

namespace EX4.Models
{
    public partial class Investigador
    {
        public Investigador()
        {
            Reservas = new HashSet<Reserva>();
        }

        public string DNI { get; set; }
        public string NomApels { get; set; }
        public int Facultad { get; set; }

        public virtual Facultad Facultades { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
