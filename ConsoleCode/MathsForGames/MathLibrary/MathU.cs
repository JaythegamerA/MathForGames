namespace MathLibrary
{
    public static class MathUtils
    {

        public const float DefaultTolerance = 0.0001f;
        public static bool ApproximatelyEqual(float a, float b, float maxDelta = DefaultTolerance)
        {
            return MathF.Abs(a - b) < maxDelta;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min) { return min; }
            else if (value > max) { return max; }

            return value;
        }

        public static float AngleFrom2D(float x, float y)
        {
            return MathF.Atan2(y, x);
        }

        public const float Deg2Rad = MathF.PI * 2.0f / 360.0f;

        public const float Rad2Deg = 1.0f / Deg2Rad;
    }
}