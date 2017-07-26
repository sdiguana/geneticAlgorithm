using System;

namespace geneticAlgorithm
{
    public static class Rand
    {
        //https://stackoverflow.com/questions/767999/random-number-generator-only-generating-one-random-number
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int Random(int min, int max)
        {
            lock (syncLock)
            {
                // synchronize
                return random.Next(min, max);
            }
        }
    }
}
