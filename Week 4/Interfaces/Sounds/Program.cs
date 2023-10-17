using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sounds
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            List<ISound> sounds = new List<ISound>();
            sounds.Add(new Human());
            sounds.Add(new Dog());
            sounds.Add(new Cat());

            foreach (var s in sounds)
            {
                s.MakeNoise();
            }
        }
    }
}
