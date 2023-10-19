using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WithDatabase
{
    // De database in code (DbContext)
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
            //Model2 hierboven is de naam van de configuratie parameter (App.config) die de connectiestring bevat
        }

        // Elke DbSet is een tabel in code
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Fluent API voor meer geavanceerde zaken
            modelBuilder.Entity<Student>()
                .Property(e => e.Naam)
                .IsUnicode(false);
        }
    }
}
