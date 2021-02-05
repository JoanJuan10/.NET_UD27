using System;
using System.Collections.Generic;

namespace EX3.Models
{
    public partial class Maquina
    {
        public Maquina()
        {
            Venta = new HashSet<Venta>();
        }

        public int Codigo { get; set; }
        public int Piso { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }

    }
}
