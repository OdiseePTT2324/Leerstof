using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sounds
{
    internal class Dog: ISound
    {
        public void MakeNoise()
        {
            Console.WriteLine("Woof");
        }
    }
}
