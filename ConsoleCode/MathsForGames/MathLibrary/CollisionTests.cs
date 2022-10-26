using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibrary
{
    public static class CollisionTests
    {
        public static bool CirclePointTest(Vector3 circlePosition, float circleRadius, Vector3 pointPosition)
        {
            /* SLOW IMPLEMENTATION
            //get the distance
            float distance = (circlePosition - pointPosition).Magnitude;
            //compare to radius of circle, if less collision, if more no collision
            return distance <= circleRadius;
            */
            //FASTER IMPLEMENTATION
            Vector3 offset = circlePosition - pointPosition;
            float distanceSquared = offset.Dot(offset);

            return distanceSquared <= circleRadius * circleRadius;
        }

        public static bool CircleCircleTest(Vector3 circleOnePos, float circleOneR, Vector3 circleTwoPos, float circleTwoR)
        {
            //cache the distance between the center of both circles
            Vector3 centerDeltaDistance = circleOnePos - circleTwoPos;
            //cache the combined radius
            float combinedRadii = circleOneR + circleTwoR;

            //check if the distance between the two centers (squared) is less than or equal to the combined radii (squared)
            return (centerDeltaDistance.Dot(centerDeltaDistance)) <= (combinedRadii * combinedRadii);
        }
    }


}