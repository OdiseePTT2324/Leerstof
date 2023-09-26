using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voter
{
    public class Person
    {
        public int Age;
        public Person(int age) 
        {
            Age = age;
        }

        public bool CanVote()
        {
            return Age >= 18; // verborgen if - twee mogelijke uitkomsten, minstens 2 testen
        }
    }
}
