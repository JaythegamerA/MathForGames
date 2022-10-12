using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public class MathU
    {
        public const float DegreeToRadians = MathF.PI * 2.0f / 360.0f;


        public const float RadiansToDegrees = 1.0f / DegreeToRadians;

        public static float AngleFrom2D(float x, float y)
        {
            return MathF.Atan2(y, x);
        }
    }
}