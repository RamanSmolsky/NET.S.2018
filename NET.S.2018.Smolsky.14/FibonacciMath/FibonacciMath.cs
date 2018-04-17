using System;
using System.Collections.Generic;

namespace Fibonacci
{
    /// <summary>
    /// Provides methods to work with Fibonacci sequences
    /// </summary>
    public static class FibonacciMath
    {
        /// <summary>
        /// Generates the sequence of Fibonacci number of requested length
        /// </summary>
        /// <param name="numberOfElements"></param>
        /// <returns>int[] of elements</returns>
        public static int[] GetFibonacciNumbers(int numberOfElements)
        {
            if (numberOfElements <= 0)
            {
                throw new ArgumentOutOfRangeException($"number of elements to generate ({nameof(numberOfElements)}) should be > 0");
            }

            if (numberOfElements == 1)
            {
                return new int[] { 1 };
            }

            if (numberOfElements == 2)
            {
                return new int[] { 1, 1 };
            }

            List<int> tempList = new List<int> { 1, 1 };

            for (int i = 2; i < numberOfElements; i++)
            {
                if (WillBeIntOverflow(tempList[i - 2], tempList[i - 1]))
                {
                    throw new ArgumentOutOfRangeException($"value of elements in the list exceeded int.MaxValue, number of elements requrested {numberOfElements}");
                }

                tempList.Add(tempList[i - 2] + tempList[i - 1]);
            }

            return tempList.ToArray();
        }

        /// <summary>
        /// Generates the sequence of Fibonacci number of requested length
        /// </summary>
        /// <param name="numberOfElements"></param>
        /// <returns>elements one by one</returns>
        public static IEnumerable<int> GetFibonacciNumbersYeild(int numberOfElements)
        {
            if (numberOfElements <= 0)
            {
                throw new ArgumentOutOfRangeException($"number of elements to generate ({nameof(numberOfElements)}) should be > 0");
            }

            if (numberOfElements == 1)
            {
                yield return 1;
            }

            if (numberOfElements == 2)
            {
                yield return 1;
                yield return 1;
            }

            yield return 1;
            yield return 1;

            int prev = 1;
            int next = 1;

            for (int i = 2; i < numberOfElements; i++)
            {
                if (WillBeIntOverflow(prev, next))
                {
                    throw new ArgumentOutOfRangeException($"value of elements in the list exceeded int.MaxValue, number of elements requrested {numberOfElements}");
                }

                int temp = next;
                next = prev + next;
                prev = temp;
                yield return next;
            }
        }

        #region private members
        private static bool WillBeIntOverflow(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                throw new ArgumentOutOfRangeException($"values of {nameof(a)} and {nameof(b)} should be positive");
            }

            // non-obvious moment - cast to long is shown as redundant here,
            // but for this check it is required, as otherwise sum of large
            // positive integeres will become negative integer (as there is no
            // check of overflow), and comparison with int.MaxValue will not work
            long tempRes = (long)a + (long)b;

            return tempRes > int.MaxValue;
        }
        #endregion
    }
}