using System;
using System.Collections.Generic;

namespace EX2.Models
{
    public partial class Asignado
    {
        public string DNICientifico { get; set; }
        public string IDProyecto { get; set; }
        public virtual Cientifico Cientificos { get; set; }
        public virtual Proyecto Proyectos { get; set; }

    }
}
