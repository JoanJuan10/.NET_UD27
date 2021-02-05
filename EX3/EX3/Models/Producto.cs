using System.Collections.Generic;

namespace EX3.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Venta = new HashSet<Venta>();
        }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }


    }
}