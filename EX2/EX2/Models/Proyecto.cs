using System.Collections.Generic;

namespace EX2.Models
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            ProyectoAsignadoA = new HashSet<Asignado>();
        }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Horas { get; set; }

        public virtual ICollection<Asignado> ProyectoAsignadoA { get; set; }


    }
}