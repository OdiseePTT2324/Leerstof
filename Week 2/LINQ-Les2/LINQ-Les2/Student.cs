using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Les2
{
    public class Student
    {
        public String Firstname {  get; set; }
        public String Lastname { get; set; }
        public int Age { get; set; }

        public Student(String firstname, String lastname, int age) { 
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Age = age;
        }
    }
}
