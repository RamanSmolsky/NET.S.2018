using System;

using IntJaggedArraySorting;
using NUnit.Framework;

namespace IntJaggedArraySortingTests
{
    [TestFixture]
    public class IntJaggedArraySortingByDelegateTests
    {
        private const string IncorrectSortBySumMsg = "jagged array was sorted by Sum incorrectly";
        private const string IncorrectSortByMaxValueMsg = "jagged array was sorted by Max value incorrectly";
        private const string IncorrectSortByMinValueMsg = "jagged array was sorted by Min value incorrectly";

        #region sorting with Delegate passed via class, by Sum, ascending

        [Test]
        public void ByDelegateViaClassSortBySumAscTwoArraysWithOneElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { 2 } };            
            BubbleSort.Sort(arrayToSort, new SortBySumAscDelegate().CompareIntArrays);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        #endregion sorting with Delegate passed via class, by Sum, ascending

        #region sorting with Delegate passed via method, by Sum, ascending

        [Test]
        public void ByDelegateMethodSortBySumAscTwoArraysWithOneElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, CompareBySum);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        #endregion sorting with Delegate passed via method, by Sum, ascending

        #region private methods

        private static bool AreJaggedIntArraysEqual(int[][] expected, int[][] actual)
        {
            if (expected == null || actual == null)
            {
                throw new ArgumentNullException($"either {nameof(expected)} or {nameof(actual)} or both are null");
            }

            int expectedLength = expected.Length;
            int actualLength = actual.Length;

            if (expectedLength != actualLength)
            {
                return false;
            }

            bool res = true;

            for (int i = 0; i < expectedLength; i++)
            {
                if (expected[i] == null & actual[i] == null)
                {
                    continue;
                }

                if (expected[i] == null || actual[i] == null)
                {
                    return false;
                }

                int numOfElementsExpected = expected[i].Length;
                int numOfElementsActual = actual[i].Length;

                if (numOfElementsExpected != numOfElementsActual)
                {
                    return false;
                }

                for (int j = 0; j < numOfElementsExpected; j++)
                {
                    if (expected[i][j] != actual[i][j])
                    {
                        return false;
                    }
                }
            }

            return res;
        }

        private static int CompareBySum(int[] x, int[] y)
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

        private static long SumOf(int[] arrayToCountSum)
        {
            long sumOf = 0;

            foreach (int element in arrayToCountSum)
            {
                sumOf += element;
            }

            return sumOf;
        }

        #endregion private methods
    }
}