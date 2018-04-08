using System;
using System.Collections.Generic;

namespace IntJaggedArraySorting
{
    public class SortByMaxElementAscending : IComparer<int[]>
    {
        public int CompareIntArrays(int[] lhs, int[] rhs)
        {
            return Compare(lhs, rhs);
        }

        public int Compare(int[] x, int[] y)
        {
            if (x == null & y == null)
            {
                return 0;
            }

            if (x == null & y != null)
            {
                return 1;
            }

            if (x != null & y == null)
            {
                return -1;
            }

            if (MaxElementOf(x) < MaxElementOf(y))
            {
                return 1;
            }
            else if (MaxElementOf(x) == MaxElementOf(y))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        #region private members
        private static long MaxElementOf(int[] arrayToFindMaxElement)
        {
            if (arrayToFindMaxElement == null)
            {
                throw new ArgumentNullException($"{nameof(arrayToFindMaxElement)} should not be null");
            }

            int res = int.MinValue;

            foreach (var element in arrayToFindMaxElement)
            {
                if (element > res)
                {
                    res = element;
                }
            }

            return res;
        }

        #endregion
    }
}
