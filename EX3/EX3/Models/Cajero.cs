using System;
using System.Collections.Generic;

namespace EX3.Models
{
    public partial class Cajero
    {
        public Cajero()
        {
            Venta = new HashSet<Venta>();
        }

        public int Codigo { get; set; }
        public string NomApels { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }

    }
}
