using System;
using System.Collections.Generic;

namespace EX1.Models
{
    public partial class Pieza
    {
        public Pieza()
        {
            Suministras = new HashSet<Suministra>();
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Suministra> Suministras { get; set; }

    }
}
