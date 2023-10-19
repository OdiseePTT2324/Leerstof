using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WithoutDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // install entity framework (NuGet: indien er problemen mee zijn: doe het niet in een shared folder)

            // Maak UserContext klasse dat overerft van DbContext

            // ConnectionString in app.config:
            // < connectionStrings >
            // < add name = "Users" connectionString = "data source=(localdb)\MSSQLLOCALDB;initial catalog=users;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName = "System.Data.SqlClient" />
            // </ connectionStrings >
            // kopieer dit van withDatabase en vervang Students met users

            // Link DbContext met de connectionstring
            // make constructor in UserContext
            // UserContext(): base("Users")

            // maak een User dataklasse met de properties
            // id
            // firstname
            // lastname

            /*
            [Key]
            public int Id { get; set; }

            [Required]
            [Column("Voornaam")]
            [StringLength(200)]
            public string FirstName { get; set; }

            [Required]
            [Column("Achternaam")]
            [StringLength(200)]
            //[NotMapped] -- wordt niet opgeslaan
            public String LastName { get; set; }
            */

            // add dbset in dbcontext

            // Vraag: maak een tweede dataklasse aan Car met de properties
            // id
            // merk
            // model

            /*
            
            [Key]
            public int id { get; set; }

            [Required]
            [Column("Merk")]
            [StringLength(50)]
            public string merk { get; set; }

            [Column("Model")]  // wijzigt kolomnaam in database
            [StringLength(50)]
            public string model { get; set; }
             */

            // fluent api om een aantal karakteristieken in te stellen
            /*
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Car>().Property(car => car.Model)
                    .HasMaxLength(50)
                    .IsOptional()
                    .HasColumnName("Model");
            }
            */

            //de veel-op-veel relatie
            /*
            modelBuilder.Entity<User>()
                .HasMany<Car>(user => user.Cars)
                .WithMany(car => car.Users);
            */

            // make context en start application
            //insertData();

            //let them add some more data
            // use the view -> sql server object explorer and look at the inserted an generated data

            // delete Data

            //change some data and verify it is changed
            //changeData();

            // change Data2

            // add repositories
            // eerst zonder include

            UserRepository userRepository = new UserRepository();
            List<User> users = userRepository.GetAllUsers();

            Console.WriteLine(users.First().Cars.Count);
            //Console.ReadKey();

            // met include
            List<User> users2 = userRepository.GetAllUsersWithCars();
            Console.WriteLine(users2.First().Cars.Count);
            Console.ReadKey();

            // reeds getoond maar leg nog eens de nadruk dat LINQ en lambda expressions werken op de dbset

            // migraties uitleggen
        }

        public static void insertData2()
        {
            UserContext userContext = new UserContext();

            User user = new User();
            user.FirstName = "Jan";
            user.LastName = "Jansens";

            userContext.Users.Add(user);
            userContext.SaveChanges();

            userContext.Users.ToList();
        }

        public static void insertData()
        {
            UserContext userContext = new UserContext();

            User user = new User();
            user.FirstName = "Jan";
            user.LastName = "Jansens";

            Car car = new Car();
            car.Merk = "Tesla";
            car.Model = "Model S";

            user.Cars.Add(car);

            userContext.Users.Add(user);
            userContext.Cars.Add(car);

            userContext.SaveChanges();

            userContext.Users.ToList();
        }
        public static void deleteData()
        {
            UserContext context = new UserContext();

            User user = context.Users.First(u => u.FirstName == "Jan");
            context.Users.Remove(user);

            context.SaveChanges();

        }
        public static void changeData()
        {
            UserContext context = new UserContext();
            UserContext context2 = new UserContext();

            User user = context.Users.First(u => u.FirstName == "Jan");
            User user2 = context2.Users.First(u => u.FirstName == "Bert");

            user.FirstName = "Homer";
            user2.FirstName = "Marge";

            context.SaveChanges();

            //which changes are added?
        }
        public static void changeData2()
        {
            UserContext context = new UserContext();
            UserContext context2 = new UserContext();

            User user = context.Users.First(u => u.FirstName == "Jan");
            User user2 = context.Users.First(u => u.FirstName == "John");

            user.FirstName = "Harry";
            user2.FirstName = "Ron";
            context.Entry(user2).State = EntityState.Modified;

            context.SaveChanges();

            //which changes are added?
        }
    }
}
