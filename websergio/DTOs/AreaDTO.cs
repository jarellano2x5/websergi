using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace websergio.DTOs
{
    public class AreaDTO
    {
        public int Id { get; set; }
        public int IdColonia { get; set; }
        public string Puntos { get; set; }
        public bool Activo { get; set; }
    }
}