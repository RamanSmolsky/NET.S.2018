using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntJaggedArraySorting
{
    public class SortByMinElementDescending : IComparer<int[]>
    {
        public int Compare(int[] x, int[] y)
        {
            if (x == null & y == null)
            {
                return 0;
            }

            if (x == null & y != null)
            {
                return -1;
            }

            if (x != null & y == null)
            {
                return 1;
            }

            if (MinElementOf(x) < MinElementOf(y))
            {
                return -1;
            }
            else if (MinElementOf(x) == MinElementOf(y))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        #region private members
        private static long MinElementOf(int[] arrayToFindMinElement)
        {
            if (arrayToFindMinElement == null)
            {
                throw new ArgumentNullException($"{nameof(arrayToFindMinElement)} should not be null");
            }

            int res = int.MaxValue;

            foreach (var element in arrayToFindMinElement)
            {
                if (element < res)
                {
                    res = element;
                }
            }

            return res;
        }
        #endregion
    }
}