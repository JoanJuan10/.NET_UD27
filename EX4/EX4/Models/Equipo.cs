using System;
using System.Collections.Generic;

namespace EX4.Models
{
    public partial class Equipo
    {
        public Equipo()
        {
            Reservas = new HashSet<Reserva>();
        }

        public string NumSerie { get; set; }
        public string Nombre { get; set; }
        public int IDFacultad { get; set; }
        public virtual Facultad Facultad { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
