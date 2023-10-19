using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guesser
{
    public interface IRandom
    {
        int Next(int maxNumber);
    }

    public class RandomWrapper : IRandom
    {
        private Random _random;
        public int Next(int maxNumber)
        {
            return _random.Next(maxNumber);
        }
    }
}
