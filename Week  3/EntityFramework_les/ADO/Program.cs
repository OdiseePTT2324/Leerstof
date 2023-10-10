using System;
using System.Data.SqlClient;

namespace ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // open view -> sql server object explorer
            // open localdb -> databases add "studenten" database
            // execute the query:

            /*
             CREATE TABLE [dbo].[Student]
            (
            [Id] INT NOT NULL PRIMARY KEY, 
            [Naam] VARCHAR(50) NULL, 
            [Score] INT NULL
            )
            */

            // execute the following queries for some data

            /*
            insert into Student values(1, 'Lisa', 15)
            insert into Student values(2, 'Kenny', 16)
            insert into Student values(3, 'Marge', 12)
            insert into Student values(4, 'Bart', 9)
            */

            // select statement

            /*
            select * from Student
             */

            // update statement

            /*
            update Student set Student.Score=11 where Student.Naam='Bart'; 
            select * from Student
             */

            // find connection sring in sql server object explorer (watch out for single \)
            string connectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = studenten; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            SqlConnection connection = new SqlConnection(connectionstring);
            SqlCommand command = new SqlCommand("select Naam from Student", connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0]);
            }

            reader.Close();
            connection.Close();

            Console.ReadLine();

            // Oefening: Bepaal het gemiddelde van alle scores in de tabel

            // Vraag: Schuilt er een probleem in bovenstaande aanpak?
            // Antwoord: SQL injection
            // Select Score where Naam='" + naam + "';"
            // en naam is "Tom'; Drop Table Student; --" (laatste zet de rest in commentaar)

            // maak nieuwe console applicatie aan (.net framework)
            // ga verder in WithDatabase project
        }
    }
}
