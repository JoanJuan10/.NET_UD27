using System.Collections.Generic;

namespace EX1.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Suministras = new HashSet<Suministra>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Suministra> Suministras { get; set; }


    }
}