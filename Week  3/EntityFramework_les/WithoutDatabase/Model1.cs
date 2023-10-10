using System;
using System.Data.Entity;
using System.Linq;

namespace WithoutDatabase
{
    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WithoutDatabase.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Fluent API voor meer geavanceerde zaken
            base.OnModelCreating(modelBuilder);

            // Een M op N relatie
            modelBuilder.Entity<User>()
                .HasMany<Car>(user => user.alleAutos)
                .WithMany(car => car.Gebruikers);
        }
    }
}