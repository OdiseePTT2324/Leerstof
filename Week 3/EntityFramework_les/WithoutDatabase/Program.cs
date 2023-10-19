using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Model1 model1 = new Model1();

            // Let op dit is anders dan in de slides , lambda expressie werkt niet meer
            List<User> users = model1.Users.Include("alleAutos").ToList();

            model1.Users.Add(new User("Harry", "Potter"));
            model1.Users.Add(new User("Ron", "Weasley"));
            model1.Users.Add(new User("Hermoine", "Granger"));
            model1.Users.Add(new User("Voornaam", "Achternaam"));

            Car c = new Car("Ford", "Fiesta");
            foreach(User u in model1.Users)
            {
                u.favorieteAuto = c;
                u.alleAutos.Add(c);
            }

            model1.Cars.Add(c);
            model1.Cars.Add(new Car("Tesla", "Model s"));

            model1.SaveChanges();
        }
    }
}
