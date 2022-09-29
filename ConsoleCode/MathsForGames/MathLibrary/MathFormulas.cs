namespace AIE
{
    public static class MathFormulas
    {
        //Problem A
        public static float BasicQuadratic(float x)
        {
            return x * x + 2 * x - 7;
        }

        //Problem B
        public struct QuadraticRoots
        {
            public float rootA;
            public float rootB;
            public bool hasRoots;
        }

        public static QuadraticRoots GetQuadraticRoots(float a, float b, float c)
        {
            float numA = -b + MathF.Sqrt(b * b - 4 * a * c);
            float numB = -b - MathF.Sqrt(b * b - 4 * a * c);

            float den = 2 * a;

            QuadraticRoots roots = new QuadraticRoots();
            roots.rootA = numA / den;
            roots.rootB = numB / den;

            if ((b * b - 4 * a * c) < 0)
            {
                roots.hasRoots = false;
            }
            else
            {
                roots.hasRoots = true;
            }

            return roots;
        }

        //Problem C

        public static float LinearEquation(float s, float e, float t)
        {
            float result = s + t * (e - s);
            return result;
        }

        //Problem D

        public static float Distance(float x1, float y1, float x2, float y2)
        {
            return MathF.Sqrt((x2 - x1) * (x2 - x1) * (y2 - y1) * (y2 - y1));
        }

        //Problem E


    }
}