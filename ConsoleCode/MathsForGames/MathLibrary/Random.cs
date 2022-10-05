namespace MathLibrary
{
    public static class Random
    {
        private static System.Random instance = new System.Random();

        //Sets the random number to a seed that you assign
        public static void SetSeed(int seed)
        {
            seed = Value;
        }

        //Generates Random Numbers
        public static int Value
        {
            get
            {
                return instance.Next();
            }
        }

        public static float ValueF
        {
            get
            {
                return instance.NextSingle();
            }
        }


        //Sets the minimum and maximum range for generating random numbers
        public static int Range(int minInclusive, int maxInclusive)
        {
            return instance.Next(minInclusive, maxInclusive + 1);
        }

        public static float Range(float minInclusive, float maxInclusive)
        {
            float temp = instance.NextSingle();
            temp *= maxInclusive;
            temp += minInclusive;
            if (temp > maxInclusive)
            {
                return maxInclusive;
            }
            return temp;
        }
    }
}