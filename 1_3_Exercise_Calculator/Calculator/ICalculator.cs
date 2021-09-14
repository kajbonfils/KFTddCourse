using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface ICalculator
    {
        int Add(int augend, int addend);
        int Subtract(int minuend, int subtrahend);

        int Multiply(int multiplicand, int multiplier);

        double Divide(int dividend, int divisor);
    }
}
