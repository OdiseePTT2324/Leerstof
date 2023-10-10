using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String naam = "Tom'; Drop Table Student; --";

            // Hoe vind je de connectie string?
            // selecteer de database server -> properties -> helemaal bovenaan staat de connection string
            // Vervang de master in Initial Catalog met de database die je wil gebruiken
            SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=demo;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            SqlCommand cmd = new SqlCommand($"Select * from Student where Naam='{naam}'", conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // ID, Naam, Score
                // Print de Score uit of kolom met index 2
                Console.WriteLine(reader[2]);
            }

            reader.Close();
            conn.Close();

            Console.ReadLine();
        }
    }
}
