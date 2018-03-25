using System;

using IntJaggedArraySorting;
using NUnit.Framework;

namespace IntJaggedArraySortingTests
{
    [TestFixture]
    public class IntJaggedArraySortingBySumTests
    {
        private const string IncorrectSortBySumMsg = "jagged array was sorted by Sum incorrectly";
        private const string IncorrectSortByMaxValueMsg = "jagged array was sorted by Max value incorrectly";
        private const string IncorrectSortByMinValueMsg = "jagged array was sorted by Min value incorrectly";

        #region tests for sorting by Sum

        [Test]
        public void SortBySumAscTwoArraysWithOneElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void SortBySumAscTwoArraysWithOneNegativeElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void SortBySumAscTwoArraysWithOneNegativeElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { -2 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void SortBySumAscTwoArraysWithOneMaxIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MaxValue } };
            BubbleSort.Sort(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void SortBySumAscTwoArraysWithOneMinIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { int.MinValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void SortBySumAscTwoArraysWithZeroedSubArraysUnsortedTest()
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
            BubbleSort.Sort(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void SortBySumAscOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.Sort(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void SortBySumAscTwoSubarrayOneIsNullSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.Sort(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void SortBySumAscTwoSubarraysOneIsNullNotSortedTest()
        {
            int[][] arrayToSort = { null, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.Sort(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void SortBySumAscTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.Sort(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void ArgumentIsNull_Should_ThroughArgumentNullExceptionTest()
        {
            int[][] arrayToSort = null;
            Assert.Catch(typeof(ArgumentNullException), () => BubbleSort.Sort(arrayToSort), "required type of exception is not thrown");
        }

        [Test]
        public void SortBySumSumOfSubArrayExceedsLongTest()
        {
            throw new NotImplementedException();
        }

        #endregion tests for sorting by Sum

        #region tests for sorting by Max value

        [Test]
        public void SortByMaxValueAscTwoArraysWithOneElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueDescTwoArraysWithOneElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueAscTwoArraysWithOneNegativeElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueDescTwoArraysWithOneNegativeElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { -2 } };
            BubbleSort.Sort(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueAscTwoArraysWithOneMaxIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MaxValue } };
            BubbleSort.Sort(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueDescTwoArraysWithOneMaxIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { int.MaxValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueAscTwoArraysWithOneMinIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { int.MinValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueDescTwoArraysWithOneMinIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MinValue } };
            BubbleSort.Sort(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueAscTwoArraysWithZeroedSubArraysUnsortedTest()
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
            BubbleSort.Sort(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueDescTwoArraysWithZeroedSubArraysUnsortedTest()
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
            BubbleSort.Sort(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueAscOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.Sort(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueDescOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.Sort(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueAscTwoSubarrayOneIsNullSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.Sort(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueDescTwoSubarrayOneIsNullNotSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueAscTwoSubarraysOneIsNullNotSortedTest()
        {
            int[][] arrayToSort = { null, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.Sort(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueDescTwoSubarraysOneIsNullNotSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueAscTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.Sort(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMaxValueDescTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.Sort(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        #endregion tests for sorting by Max value

        #region tests for sorting by Min value

        [Test]
        public void SortByMinValueAscTwoArraysWithOneElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void SortByMinValueDescTwoArraysWithOneElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void SortByMinValueAscTwoArraysWithOneNegativeElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void SortByMinValueDescTwoArraysWithOneNegativeElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { -2 } };
            BubbleSort.Sort(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void SortByMinValueAscTwoArraysWithOneMaxIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MaxValue } };
            BubbleSort.Sort(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void SortByMinValueDescTwoArraysWithOneMaxIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { int.MaxValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void SortByMinValueAscTwoArraysWithOneMinIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { int.MinValue }, new int[] { 1 } };
            BubbleSort.Sort(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void SortByMinValueDescTwoArraysWithOneMinIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MinValue } };
            BubbleSort.Sort(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void SortByMinValueAscTwoArraysWithZeroedSubArraysUnsortedTest()
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
            BubbleSort.Sort(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMinValueDescTwoArraysWithZeroedSubArraysUnsortedTest()
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
            BubbleSort.Sort(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMinValueAscOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.Sort(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMinValueDescOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.Sort(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMinValueAscTwoSubarrayOneIsNullNotSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMinValueDescTwoSubarrayOneIsNullSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.Sort(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMinValueAscTwoSubarraysOneIsNullSortedTest()
        {
            int[][] arrayToSort = { null, new int[] { 2 } };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.Sort(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMinValueDescTwoSubarraysOneIsNullSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.Sort(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMinValueAscTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.Sort(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMinValueDescTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.Sort(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        #endregion tests for sorting by Min value

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