using PersonAgeValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidatorTests
{
    internal class AgeValidatorTestDouble : IAgeValidator
    {
        public bool Returns { get; set; }

        public AgeValidatorTestDouble(bool returns) { 
            Returns = returns;
        }
        public bool IsValidAge(int age)
        {
            return Returns;
        }
    }
}
