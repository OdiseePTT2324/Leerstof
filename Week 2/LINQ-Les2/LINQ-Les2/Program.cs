using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Les2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<int> list = new List<int>{ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            //int som = 0;
            /*for (int i = 0; i < list.Count; i++)
            {   
                som += list[i];
            }*/
            /*
            foreach(int i in list)
            {
                som += i;
            }

            Console.WriteLine(som / list.Count);
            Console.ReadLine(); // voor te voorkomen dat het onmiddelijk sluit

            Console.WriteLine(list.Average());
            Console.WriteLine(list.Max());
            Console.WriteLine(list.Min());
            Console.ReadLine();

            foreach(int i in list.Where(x => x % 2 == 0))
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();*/

            List<Student> students = new List<Student>() {
                new Student("Albus", "Perkamentus", 150),
                new Student("Harry", "Potter", 12),
                new Student("Ron", "Weasley", 18)
            };

            Console.WriteLine(students.Average(GetAge));
            // met lambda expressies     (//input parameters net zoals bij functiedefinitie)
            Console.WriteLine(students.Average(  (Student x) => { return x.Age; }       ));
            // paar vereenvoudigingen mogelijk
            // als er geen verwarring mogelijk is mag die Student weg
            Console.WriteLine(students.Average((x) => { return x.Age; }));
            // als er maar inputparameter is, mogen de ronde haakjes weg
            Console.WriteLine(students.Average( x  => { return x.Age; }));
            // als er maar 1 lijn is in de body, mogen de accolades, return en puntkomma weg
            Console.WriteLine(students.Average( x => x.Age));

            Console.WriteLine(students.Sum(x => x.Firstname.Length));

            // Filteren (return true => deze elementen worden geselecteerd)
            Console.WriteLine(students.Where(x => x.Age < 100).ToList().Count);

            // Select doe een transformatie, zet x om naar iets anders
            Console.WriteLine(students.Select(x => x.Lastname).Where(x => x.Length < 8));

            Console.ReadLine();

            List<StudentWithGender> studentsWithGender = new List<StudentWithGender>() {
                new StudentWithGender("Albus", "Perkamentus", 150, Gender.Male),
                new StudentWithGender("Harry", "Potter", 12, Gender.Male),
                new StudentWithGender("Ron", "Weasley", 18, Gender.Male),
                new StudentWithGender("Hermoine", "Gringer", 15, Gender.Female)
            };

            studentsWithGender.Where(x => x.Age > 18 && x.Gender == Gender.Male);

        }

        static int GetAge(Student student)
        {
            return student.Age;
        }
    }
}
