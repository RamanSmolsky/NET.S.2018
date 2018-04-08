namespace IntJaggedArraySorting
{
    public class SortBySumAscDelegate : ICompareIntArray
    {
        public int CompareIntArrays(int[] lhs, int[] rhs)
        {
            if (lhs == null & rhs == null)
            {
                return 0;
            }

            if (lhs == null & rhs != null)
            {
                return 1;
            }

            if (lhs != null & rhs == null)
            {
                return -1;
            }

            if (SumOf(lhs) < SumOf(rhs))
            {
                return 1;
            }
            else if (SumOf(lhs) == SumOf(rhs))
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