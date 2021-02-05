using System;
using System.Collections.Generic;

namespace EX4.Models
{
    public partial class Reserva
    {
        public string DNI { get; set; }
        public string NumSerie { get; set; }
        public DateTime Comienzo { get; set; }
        public DateTime Fin { get; set; }

        public virtual Investigador Investigadores { get; set; }
        public virtual Equipo Equipos { get; set; }
    }
}