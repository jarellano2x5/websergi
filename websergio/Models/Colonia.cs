using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace websergio.Models
{
    public class Colonia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public virtual List<Area> Areas { get; set; }
    }
}