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
            // Voeg Nuget package entity framework toe
            // Rechtsklikken op het project -> add -> new item -> data category -> ADO.net Object Data Model
            // Kies Code First from Database
            // Add new connection (tenzij hij er al bij staat)
            // Server name = (localdb)\MSSQLLocalDB
            // Kies de juiste database uit de dropdown
            // Maak de connectie aan en klik next
            // Kies de tabellen die je wil toevoegen
            // Geef eventueel het model een naam
            // Vervolledig de stappen tot je een Model.cs klasse te zien krijgt

            Model2 model = new Model2();
            foreach(Student s in model.Student) {
                Console.WriteLine(s.Naam + " " + s.Score);
            }

            Student student = new Student(new Random().Next(1000000000), "lkajfl;djal;jfdalk;j");
            model.Student.Add(student);
            model.SaveChanges();
            
            Console.WriteLine(model.Student.Average(s => s.Score));
        }
    }
}
