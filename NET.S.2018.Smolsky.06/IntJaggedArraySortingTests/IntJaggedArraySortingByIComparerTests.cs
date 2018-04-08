using System;

using IntJaggedArraySorting;
using NUnit.Framework;

namespace IntJaggedArraySortingTests
{
    [TestFixture]
    public class IntJaggedArraySortingByIComparerTests
    {
        private const string IncorrectSortBySumMsg = "jagged array was sorted by Sum incorrectly";
        private const string IncorrectSortByMaxValueMsg = "jagged array was sorted by Max value incorrectly";
        private const string IncorrectSortByMinValueMsg = "jagged array was sorted by Min value incorrectly";

        #region sorting by Sum, ascending

        [Test]
        public void IComparerSortBySumAscTwoArraysWithOneElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortBySumAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumAscTwoArraysWithOneNegativeElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortBySumAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumAscTwoArraysWithOneNegativeElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { -2 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortBySumAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumAscTwoArraysWithOneMaxIntElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MaxValue } };
            BubbleSort.Sort(arrayToSort, new SortBySumAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumAscTwoArraysWithOneMinIntElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { int.MinValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortBySumAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumAscTwoArraysWithZeroedSubArraysUnSortedTest()
        {
            int[][] arrayToSort =
                {
                    new int[] { 1 },
                    new int[] { 0 },
                    new int[] { 5 },
                    new int[] { 0 },
                    new int[] { -3 },
                };
            int[][] arrayToSortExpected =
                {
                    new int[] { -3 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { 1 },
                    new int[] { 5 }
                };
            BubbleSort.Sort(arrayToSort, new SortBySumAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumAscOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.Sort(arrayToSort, new SortBySumAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumAscTwoSubarrayOneIsNullSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortBySumAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumAscTwoSubarraysOneIsNullSortedTest()
        {
            int[][] arrayToSort = { null, new int[] { 2 } };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortBySumAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumAscTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.Sort(arrayToSort, new SortBySumAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerArgumentIsNull_Should_ThroughArgumentNullExceptionTest()
        {
            int[][] arrayToSort = null;
            Assert.Catch(typeof(ArgumentNullException), () => BubbleSort.Sort(arrayToSort, new SortBySumAscending()), "required type of exception is not thrown");
        }

        [Test]
        public void IComparerSortBySumSumOfSubArrayExceedsLongTest()
        {
            throw new NotImplementedException();
        }

        #endregion sorting by Sum, ascending

        #region sorting by Sum, descending

        [Test]
        public void IComparerSortBySumDescTwoArraysWithOneElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortBySumDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumDescTwoArraysWithOneNegativeElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { -2 } };
            BubbleSort.Sort(arrayToSort, new SortBySumDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumDescTwoArraysWithOneNegativeElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { -2 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { -2 } };
            BubbleSort.Sort(arrayToSort, new SortBySumDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumDescTwoArraysWithOneMaxIntElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { int.MaxValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortBySumDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumDescTwoArraysWithOneMinIntElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MinValue } };
            BubbleSort.Sort(arrayToSort, new SortBySumDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumDescTwoArraysWithZeroedSubArraysUnSortedTest()
        {
            int[][] arrayToSort =
                {
                    new int[] { 1 },
                    new int[] { 0 },
                    new int[] { 5 },
                    new int[] { 0 },
                    new int[] { -3 },
                };
            int[][] arrayToSortExpected =
                {
                    new int[] { 5 },
                    new int[] { 1 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { -3 }
                };
            BubbleSort.Sort(arrayToSort, new SortBySumDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumDescOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.Sort(arrayToSort, new SortBySumDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumDescTwoSubarrayOneIsNullUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortBySumDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumDescTwoSubarraysOneIsNullSortedTest()
        {
            int[][] arrayToSort = { null, new int[] { 2 } };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortBySumDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void IComparerSortBySumDescTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.Sort(arrayToSort, new SortBySumDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        #endregion sorting by Sum, descending

        #region sorting by Max value, ascending

        [Test]
        public void IComparerSortByMaxValueAscTwoArraysWithOneElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscTwoArraysWithOneElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscTwoArraysWithOneNegativeElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscTwoArraysWithOneNegativeElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { -2 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscTwoArraysWithOneMaxIntElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MaxValue } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscTwoArraysWithOneMaxIntElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MaxValue } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MaxValue } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscTwoArraysWithOneMinIntElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { int.MinValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscTwoArraysWithOneMinIntElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MinValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { int.MinValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscTwoArraysWithZeroedSubArraysUnSortedTest()
        {
            int[][] arrayToSort =
                {
                    new int[] { 1 },
                    new int[] { 0 },
                    new int[] { 5 },
                    new int[] { 0 },
                    new int[] { -3 },
                };
            int[][] arrayToSortExpected =
                {
                    new int[] { -3 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { 1 },
                    new int[] { 5 }
                };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscTwoArraysWithZeroedSubArraysSortedTest()
        {
            int[][] arrayToSort =
                {
                    new int[] { -3 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { 1 },
                    new int[] { 5 }
                };
            int[][] arrayToSortExpected =
                {
                    new int[] { -3 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { 1 },
                    new int[] { 5 }
                };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscTwoSubarrayOneIsNullUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscTwoSubarraysOneIsNullSortedTest()
        {
            int[][] arrayToSort = { null, new int[] { 2 } };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscTwoSubarraysOneIsNullUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueAscTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        #endregion sorting by Max value, ascending

        #region sorting by Max value, descending

        [Test]
        public void IComparerSortByMaxValueDescTwoArraysWithOneElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueDescTwoArraysWithOneElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueDescTwoArraysWithOneNegativeElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { -2 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueDescTwoArraysWithOneNegativeElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { -2 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { -2 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueDescTwoArraysWithOneMaxIntElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { int.MaxValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueDescTwoArraysWithOneMaxIntElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MaxValue } };
            int[][] arrayToSortExpected = { new int[] { int.MaxValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueDescTwoArraysWithOneMinIntElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MinValue } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueDescTwoArraysWithOneMinIntElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MinValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MinValue } };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueDescTwoArraysWithZeroedSubArraysUnSortedTest()
        {
            int[][] arrayToSort =
                {
                    new int[] { 1 },
                    new int[] { 0 },
                    new int[] { 5 },
                    new int[] { 0 },
                    new int[] { -3 },
                };
            int[][] arrayToSortExpected =
                {
                    new int[] { 5 },
                    new int[] { 1 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { -3 },
                };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueDescTwoArraysWithZeroedSubArraysSortedTest()
        {
            int[][] arrayToSort =
                {
                    new int[] { 5 },
                    new int[] { 1 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { -3 },
                };
            int[][] arrayToSortExpected =
                {
                    new int[] { 5 },
                    new int[] { 1 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { -3 }
                };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueDescOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueDescTwoSubarraysOneIsNullUnSortedTest()
        {
            int[][] arrayToSort = { null, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueDescTwoSubarraysOneIsNullSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMaxValueDescTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.Sort(arrayToSort, new SortByMaxElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        #endregion sorting by Max value, descending

        #region sorting by Min value, ascending

        [Test]
        public void IComparerSortByMinValueAscTwoArraysWithOneElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueAscTwoArraysWithOneElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueAscTwoArraysWithOneNegativeElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueAscTwoArraysWithOneNegativeElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { -2 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueAscTwoArraysWithOneMaxIntElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MaxValue } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueAscTwoArraysWithOneMaxIntElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MaxValue } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MaxValue } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueAscTwoArraysWithOneMinIntElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { int.MinValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueAscTwoArraysWithOneMinIntElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MinValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { int.MinValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueAscTwoArraysWithZeroedSubArraysSortedTest()
        {
            int[][] arrayToSort =
                {
                    new int[] { -3 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { 1 },
                    new int[] { 5 }
                };
            int[][] arrayToSortExpected =
                {
                    new int[] { -3 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { 1 },
                    new int[] { 5 }
                };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueAscTwoArraysWithZeroedSubArraysUnSortedTest()
        {
            int[][] arrayToSort =
                {
                    new int[] { 1 },
                    new int[] { 0 },
                    new int[] { 5 },
                    new int[] { 0 },
                    new int[] { -3 },
                };
            int[][] arrayToSortExpected =
                {
                    new int[] { -3 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { 1 },
                    new int[] { 5 }
                };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueAscOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueAscTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueAscTwoSubarrayOneIsNullUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueAscTwoSubarrayOneIsNullSortedTest()
        {
            int[][] arrayToSort = { null, new int[] { 2 } };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementAscending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        #endregion sorting by Min value, ascending

        #region sorting by Min value, descending

        [Test]
        public void IComparerSortByMinValueDescTwoArraysWithOneElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueDescTwoArraysWithOneElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueDescTwoArraysWithOneNegativeElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { -2 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { -2 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueDescTwoArraysWithOneNegativeElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { -2 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueDescTwoArraysWithOneMaxIntElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { int.MaxValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueDescTwoArraysWithOneMaxIntElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MaxValue } };
            int[][] arrayToSortExpected = { new int[] { int.MaxValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueDescTwoArraysWithOneMinIntElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MinValue } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueDescTwoArraysWithOneMinIntElementUnSortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MinValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MinValue } };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueDescTwoArraysWithZeroedSubArraysSortedTest()
        {
            int[][] arrayToSort =
                {
                    new int[] { 5 },
                    new int[] { 1 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { -3 }
                };
            int[][] arrayToSortExpected =
                {
                    new int[] { 5 },
                    new int[] { 1 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { -3 }
                };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueDescTwoArraysWithZeroedSubArraysUnSortedTest()
        {
            int[][] arrayToSort =
                {
                    new int[] { 1 },
                    new int[] { 0 },
                    new int[] { 5 },
                    new int[] { 0 },
                    new int[] { -3 },
                };
            int[][] arrayToSortExpected =
                {
                    new int[] { 5 },
                    new int[] { 1 },
                    new int[] { 0 },
                    new int[] { 0 },
                    new int[] { -3 }
                };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueDescOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueDescTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueDescTwoSubarrayOneIsNullSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void IComparerSortByMinValueDescTwoSubarrayOneIsNullUnSortedTest()
        {
            int[][] arrayToSort = { null, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.Sort(arrayToSort, new SortByMinElementDescending());
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        #endregion sorting by Min value, descending

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
        #endregion private methods
    }
}