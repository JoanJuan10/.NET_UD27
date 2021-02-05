using System;
using System.Collections.Generic;

namespace EX3.Models
{
    public partial class Venta
    {
        public int Cajero { get; set; }
        public int Maquina { get; set; }
        public int Producto { get; set; }
        public virtual Cajero Cajeros { get; set; }
        public virtual Producto Productos { get; set; }
        public virtual Maquina Maquinas { get; set; }

    }
}
