using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // add new item -> data -> ado.net -> from database

            // voeg nieuwe connectie toe: (localdb)\MSSQLLOCALDB
            // ga naar dropdown en klik studenten
            // sla de string op als studenten

            // next -> en selecteer alle tabellen (hier maar 1)

            // doorloop de wizard. Indien gelukt zijn er een aantal klassen toegevoegd
            // Model1.cs (indien gewijzigd kan het anders noemen) (zorgt voor communicatie met de database)
            // Student.cs (dit is een dataklasse/beschrijft een tabel)

            // Haal dbcontext, dbset, onmodelcreating, data annotations aan (worden later in meer detail uitgelegd)

            Model1 model1 = new Model1();  
            foreach (Student s in model1.Students)
            {
                Console.WriteLine(s.Naam);
            }

            Console.ReadKey();

            // pas bovenstaande aan om het gemiddelde te berekenen
            // Met LINQ!

            double? average = model1.Students.Average(s => s.Score);
            Console.WriteLine(average);

            // en de score van Bart te wijzigen terug naar 8 en opnieuw op te vragen (met een nieuwe context)
            Student bart = model1.Students.First(s => s.Naam == "Bart");
            int? oudeScore = bart.Score;
            bart.Score = 8;
            model1.SaveChanges();   // doe het eerst zonder deze regel!
            bart = model1.Students.First(s => s.Naam == "Bart");
            int? nieuweScore = bart.Score;

            Console.WriteLine("Bart: " + oudeScore + " => " + nieuweScore);

            Console.ReadKey();

            // ga nu naar de nieuwe console application without database
        }
    }
}
