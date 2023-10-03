using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Les2
{
    internal class StudentWithGender
    {
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public int Age { get; set; }

        public Gender Gender { get; set; }

        public StudentWithGender(String firstname, String lastname, int age, Gender gender)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Age = age;
            this.Gender = gender;
        }
    }
}
