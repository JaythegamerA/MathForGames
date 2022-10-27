using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public static class CollisionTests
    {
        public static bool CirclePointTest(Vector3 circlePos, float circleRadius, Vector3 pointPos)
        {
            Vector3 offset = circlePos - pointPos;
            float dist2 = offset.Dot(offset);

            //Compare to radius of circle
            return dist2 <= circleRadius * circleRadius;
        }
    }
}