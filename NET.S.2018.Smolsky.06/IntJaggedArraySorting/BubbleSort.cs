using System;

namespace IntJaggedArraySorting
{
    /// <summary>
    /// Defines by which method internal subarrays to be sorted:
    /// Sum - by sum of the elements
    /// MaxElement - by Maximum elements in the subarrays
    /// MinElemsnts - by Minimum elements in the subarrays
    /// </summary>
    public enum By
    {
        Sum,
        MaxElement,
        MinElement
    }

    /// <summary>
    /// Defines sorting direction - ascending or descending
    /// </summary>
    public enum Direction
    {
        Ascending,
        Descending
    }

    public class BubbleSort
    {
        #region public members
        /// <summary>
        /// Sorts jagged array of integers
        /// </summary>
        /// <param name="arrayToSort">jagged array of integers to be sorted</param>
        /// <param name="sortMethod">sorting method, <see cref="By"/>, default is <see cref="By.Sum"/></param>
        /// <param name="sortDirection">sorting direction, <see cref="Direction"/>, default is <see cref="Direction.Ascending"/></param>
        public static void Sort(int[][] arrayToSort, By sortMethod = By.Sum, Direction sortDirection = Direction.Ascending)
        {
            if (arrayToSort == null)
            {
                throw new ArgumentNullException($"{nameof(arrayToSort)} should not be null");
            }

            bool swapped = true;
            int numOfArrays = arrayToSort.Length;

            while (swapped)
            {
                swapped = false;

                for (int i = 0; i < numOfArrays - 1; i++)
                {
                    if (arrayToSort[i] == null & arrayToSort[i + 1] == null)
                    {
                        continue;
                    }

                    if (sortMethod == By.Sum || sortMethod == By.MaxElement)
                    {
                        switch (sortDirection)
                        {
                            case Direction.Ascending:
                                if (arrayToSort[i] == null & arrayToSort[i + 1] != null)
                                {
                                    swapped = true;
                                    SwapElements(ref arrayToSort[i], ref arrayToSort[i + 1]);
                                    continue;
                                }

                                if (arrayToSort[i + 1] == null & arrayToSort[i] != null)
                                {
                                    continue;
                                }

                                break;
                            case Direction.Descending:
                                if (arrayToSort[i] == null & arrayToSort[i + 1] != null)
                                {
                                    continue;
                                }

                                if (arrayToSort[i + 1] == null & arrayToSort[i] != null)
                                {
                                    swapped = true;
                                    SwapElements(ref arrayToSort[i], ref arrayToSort[i + 1]);
                                    continue;
                                }

                                break;
                        }
                    }

                    if (sortMethod == By.MinElement)
                    {
                        switch (sortDirection)
                        {
                            case Direction.Ascending:
                                if (arrayToSort[i] == null & arrayToSort[i + 1] != null)
                                {
                                    continue;
                                }

                                if (arrayToSort[i + 1] == null & arrayToSort[i] != null)
                                {
                                    swapped = true;
                                    SwapElements(ref arrayToSort[i], ref arrayToSort[i + 1]);
                                    continue;
                                }

                                break;
                            case Direction.Descending:
                                if (arrayToSort[i] == null & arrayToSort[i + 1] != null)
                                {
                                    swapped = true;
                                    SwapElements(ref arrayToSort[i], ref arrayToSort[i + 1]);
                                    continue;
                                }

                                if (arrayToSort[i + 1] == null & arrayToSort[i] != null)
                                {
                                    continue;
                                }

                                break;
                        }
                    }

                    if (IsPreceding(arrayToSort[i], arrayToSort[i + 1], sortMethod, sortDirection))
                    {
                        swapped = true;
                        SwapElements(ref arrayToSort[i], ref arrayToSort[i + 1]);
                    }
                }
            }
        }
        #endregion public members

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

        private static int MaxElement(int[] arrayToFindMaxElement)
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

        private static int MinElement(int[] arrayToFindMinElement)
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

        private static bool IsPreceding(int[] firstArray, int[] secondArray, By sortMethod, Direction sortDirection)
        {
            switch (sortMethod)
            {
                case By.Sum:
                    return sortDirection == Direction.Ascending ?
                        (SumOf(firstArray) > SumOf(secondArray)) :
                        (SumOf(firstArray) < SumOf(secondArray));
                case By.MaxElement:
                    return sortDirection == Direction.Ascending ?
                        (MaxElement(firstArray) > MaxElement(secondArray)) :
                        (MaxElement(firstArray) < MaxElement(secondArray));
                case By.MinElement:
                    return sortDirection == Direction.Ascending ?
                        (MinElement(firstArray) > MinElement(secondArray)) :
                        (MinElement(firstArray) < MinElement(secondArray));
            }

            return false;
        }

        private static void SwapElements(ref int[] element1, ref int[] element2)
        {
            int[] temp = new int[] { };

            int[] left = element1;
            int[] right = element2;

            temp = element1;
            element1 = element2;
            element2 = temp;
        }
        #endregion private members
    }
}