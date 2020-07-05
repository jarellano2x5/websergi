using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using websergio.Models;

namespace websergio.Data
{
    public class RevContext : DbContext
    {
        public RevContext() : base("revcon")
        {

        }

        public DbSet<Colonia> Colonias { get; set; }
        public DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Area>().HasRequired(c => c.Colonia)
                .WithMany(o => o.Areas)
                .HasForeignKey(m => m.IdColonia)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}