using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WithoutDatabase.Migrations;

namespace WithoutDatabase
{
    class UserContext: DbContext
    {
        public UserContext(): base("Users")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UserContext, Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().Property(car => car.Model)
                .HasMaxLength(50)
                .IsOptional()
                .HasColumnName("Reeks");

            //de veel-op-veel relatie
            modelBuilder.Entity<User>()
                .HasMany<Car>(user => user.Cars)
                .WithMany(car => car.Users);
        }
    }
}
