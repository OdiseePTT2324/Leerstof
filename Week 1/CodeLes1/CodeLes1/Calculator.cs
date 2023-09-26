using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLes1
{
    public class Calculator
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }

        public int Divide(int x, int y)
        {
            return (int) Math.Round( (double) x / (double) y);
        }
    }
}
