using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using websergio.Models;

namespace websergio.Data
{
    public class RevInitializer : DropCreateDatabaseIfModelChanges<RevContext>
    {
        protected override void Seed(RevContext context)
        {
            List<Colonia> li = new List<Colonia>
            {
                new Colonia { Nombre = "Chalco, Jardines de chalco", Activo = true },
                new Colonia { Nombre = "Chalco, 21 de marzo", Activo = true },
                new Colonia { Nombre = "Chalco, La bomba", Activo = true },
                new Colonia { Nombre = "Chalco, La conchita", Activo = true },
                new Colonia { Nombre = "Chalco, Ejidal", Activo = true }
            };
            
            foreach(Colonia col in li)
            {
                context.Colonias.Add(col);
            }
            context.SaveChanges();
        }
    }
}