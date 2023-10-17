using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sounds
{
    internal class Cat: ISound
    {
        public void MakeNoise()
        {
            Console.WriteLine("Miauw");
        }
    }
}
