using System;

namespace AIE
{
    class Program
    {
        static void Main()
        {
            MathsFormulas.QuadraticRoots roots = new MathsFormulas.QuadraticRoots();
            roots = MathsFormulas.QuadraticEquation(1f, 0f, -1f);
           
            return;
        }
    }
}