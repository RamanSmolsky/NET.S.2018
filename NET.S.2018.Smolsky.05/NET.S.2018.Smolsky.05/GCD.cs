using System;

namespace GCDbyEuclidAlgorithm
{
    public static class GCD
    {
        /// <summary>
        /// Calculates greatest common divisor for an array of integers provided, using Euclid algorithm
        /// </summary>
        /// <param name="elements">list of elements</param>
        /// <returns><see cref="int"/></returns>
        public static int CalculateGCD(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException($"{nameof(elements)} should not be null");
            }

            if (elements.Length == 1)
            {
                return Math.Abs(elements[0]);
            }

            if (elements.Length == 2)
            {
                return CalculateGCD(elements[0], elements[1]);
            }

            var next = Array.CreateInstance(typeof(int), elements.Length - 1);

            Array.Copy(elements, 1, next, 0, elements.Length - 1);

            return CalculateGCD(elements[0], CalculateGCD((int[])next));
        }

        /// <summary>
        /// Calculates greatest common divisor for two integers provided, using Euclid algorithm
        /// </summary>
        /// <param name="a">first integer</param>
        /// <param name="b">second integer</param>
        /// <returns><see cref="int"/></returns>
        private static int CalculateGCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0 & b != 0)
            {
                return b;
            }
            else if (b == 0 & a != 0)
            {
                return a;
            }

            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }

            return a;
        }
    }
}