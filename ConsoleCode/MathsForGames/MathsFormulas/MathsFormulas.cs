using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIE
{
    public static class MathsFormulas
    {
        //problem A - Basic Quadratic
        public static float QuadraticFunction(float x)
        {
            float result = (x * x) + (2 * x) - 7;
            return result;
        }

        public struct QuadraticRoots
        {
            public float rootA;
            public float rootB;
            public bool hasRoot;
        }


        //Problem B - Quadratic Equation "-B plus or minus the square root of b squared minus four A C all over 2 A"
        public static QuadraticRoots QuadraticEquation(float a, float b, float c)
        {
            QuadraticRoots root = new QuadraticRoots();

            if (MathF.Sqrt((b * b) - (4 * a * c)) < 0)
            {
                root.rootA = float.NaN;
                root.rootB = float.NaN;
                root.hasRoot = false;
                return root;
            }
            else
            {
                root.rootA = (((b * -1) + MathF.Sqrt((b * b) - (4 * a * c))) / (2 * a));
                root.rootB = (((b * -1) - MathF.Sqrt((b * b) - (4 * a * c))) / (2 * a));
                root.hasRoot = true;
                return root;
            }
        }

        //Problem C - basic linear blend equation, returns a blended variable from s to e based on a percentage variable t
        //              s + t(e - s)
        public static float LinearBlendEquation(float s, float e, float t)
        {
            return s + t * (e - s);
        }

        public struct Point
        {
            public float x;
            public float y;
            public float z;
        }

        //Problem D - distance between two points
        public static float DistanceBetweenTwoPoints(Point firstPoint, Point secondPoint)
        {
            return MathF.Sqrt(((secondPoint.x - firstPoint.x) * (secondPoint.x - firstPoint.x)) + ((secondPoint.y - firstPoint.y) * (secondPoint.y - firstPoint.y)));
        }

        //Problem E - inner products of two points
        public static float InnerProductTwoPoints(Point p, Point q)
        {
            return ((p.x * q.x) + (p.y * q.y) + (p.z * q.z));
        }

        public struct Plane
        {
            public float a;
            public float b;
            public float c;
            public float d;
        }


        //Problem F - Distance from point to plane
        //      plane - ax + by + cz + d
        //      point - x, y, z
        public static float DistanceBetweenPlaneAndPoint(Plane P, Point X)
        {
            return ((P.a * X.x) + (P.b * X.y) + (P.c * X.z) + P.d) / (MathF.Sqrt((P.a * P.a) + (P.b * P.b) + (P.c * P.c)));
        }

        //problem G - Cubic Bezier Curve
        public static float CubicBezierCurve(float t, float P0, float P1, float P2, float P3)
        {
            return (((MathF.Pow(1 - t, 3) * P0) + 3 * (MathF.Pow(1 - t, 2) * (t * P1) + 3 * ((MathF.Pow(1 - t, 2) * ((t * t) * P2)) + (MathF.Pow(t, 3) * P3)))));
        }
    }
}