﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace websergio.Models
{
    public class Area
    {
        public int Id { get; set; }
        public int IdColonia { get; set; }
        public string Puntos { get; set; }
        public bool Activo { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Colonia Colonia { get; set; }
    }
}