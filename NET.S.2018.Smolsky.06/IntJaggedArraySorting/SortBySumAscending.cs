using System.Collections.Generic;

namespace IntJaggedArraySorting
{
    public class SortBySumAscending : IComparer<int[]>
    {
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

            if (SumOf(x) < SumOf(y))
            {
                return 1;
            }
            else if (SumOf(x) == SumOf(y))
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        #region private members
        private static long SumOf(int[] arrayToCountSum)
        {
            long sumOf = 0;

            foreach (int element in arrayToCountSum)
            {
                sumOf += element;
            }

            return sumOf;
        }
        #endregion
    }
}