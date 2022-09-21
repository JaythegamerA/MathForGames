using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIE
{
  public class MathsFormulas
    {
        public static float BasicQuadratic(float x)
        {
            return x * x + 2 * x - 7;
        }
        public struct QuadraticRoots
        {
            public float rootA;
            public float rootB;
            public bool HasRoot;
        }
        public static QuadraticRoots GetQuadraticRoots(float a, float b , float c)
        {
            float numA = -b + MathF.Sqrt(b * b - 4 * a * c);
            float numb = -b + MathF.Sqrt(b * b - 4 * a * c);
            float den = 2 * a;
            QuadraticRoots roots = new QuadraticRoots();
            roots.rootA = numA;
            roots.rootB = numb;
            if((b*b-4*a*c)<0)
            {
                roots.HasRoot = false;
            }
            else
            {
                roots.HasRoot = true;
            }
            return roots;

        }
    }
}
