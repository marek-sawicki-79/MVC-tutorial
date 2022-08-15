using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorForTest
{
    public class Calculator
    {

        public double Add(double valueA, double valueB) => valueA + valueB;

        public double Substract(double valueA, double valueB) => valueA - valueB;

        public double Multiply(double valueA, double valueB) => valueA * valueB;

        public double Divide(double valueA, double valueB) 
        {
            if (valueB == 0)
                throw new ArgumentException("Divider cannot be 0");
            return valueA / valueB;
        }
    }
}
