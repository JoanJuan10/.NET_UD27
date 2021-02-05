using System;
using System.Collections.Generic;

namespace EX1.Models
{
    public partial class Suministra
    {
        
        public int CodigoPieza { get; set; }
        public int IdProveedor { get; set; }
        public int Precio { get; set; }

        public virtual Pieza Pieza { get; set; }
        public virtual Proveedor Proveedor { get; set; }

    }
}
