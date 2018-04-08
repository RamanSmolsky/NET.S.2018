using System;

using IntJaggedArraySorting;
using NUnit.Framework;

namespace IntJaggedArraySortingTests
{
    [TestFixture]
    public class OLdIntJaggedArraySortingByParametersTests
    {
        private const string IncorrectSortBySumMsg = "jagged array was sorted by Sum incorrectly";
        private const string IncorrectSortByMaxValueMsg = "jagged array was sorted by Max value incorrectly";
        private const string IncorrectSortByMinValueMsg = "jagged array was sorted by Min value incorrectly";

        #region sorting by Sum

        [Test]
        public void OldSortBySumAscTwoArraysWithOneElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { 2 } };
            BubbleSort.SortOld1(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void OldSortBySumAscTwoArraysWithOneNegativeElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.SortOld1(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void OldSortBySumAscTwoArraysWithOneNegativeElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { -2 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.SortOld1(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void OldSortBySumAscTwoArraysWithOneMaxIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MaxValue } };
            BubbleSort.SortOld1(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void OldSortBySumAscTwoArraysWithOneMinIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { int.MinValue }, new int[] { 1 } };
            BubbleSort.SortOld1(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void OldSortBySumAscTwoArraysWithZeroedSubArraysUnsortedTest()
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
            BubbleSort.SortOld1(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void OldSortBySumAscOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.SortOld1(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void OldSortBySumAscTwoSubarrayOneIsNullSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.SortOld1(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void OldSortBySumAscTwoSubarraysOneIsNullNotSortedTest()
        {
            int[][] arrayToSort = { null, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.SortOld1(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void OldSortBySumAscTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.SortOld1(arrayToSort);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortBySumMsg);
        }

        [Test]
        public void OldArgumentIsNull_Should_ThroughArgumentNullExceptionTest()
        {
            int[][] arrayToSort = null;
            Assert.Catch(typeof(ArgumentNullException), () => BubbleSort.SortOld1(arrayToSort), "required type of exception is not thrown");
        }

        [Test]
        public void OldSortBySumSumOfSubArrayExceedsLongTest()
        {
            throw new NotImplementedException();
        }

        #endregion tests for sorting by Sum

        #region sorting by Max value

        [Test]
        public void OldSortByMaxValueAscTwoArraysWithOneElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { 2 } };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueDescTwoArraysWithOneElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, new int[] { 1 } };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueAscTwoArraysWithOneNegativeElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueDescTwoArraysWithOneNegativeElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { -2 } };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueAscTwoArraysWithOneMaxIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MaxValue } };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueDescTwoArraysWithOneMaxIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { int.MaxValue }, new int[] { 1 } };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueAscTwoArraysWithOneMinIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { int.MinValue }, new int[] { 1 } };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueDescTwoArraysWithOneMinIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MinValue } };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueAscTwoArraysWithZeroedSubArraysUnsortedTest()
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
            BubbleSort.SortOld1(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueDescTwoArraysWithZeroedSubArraysUnsortedTest()
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
            BubbleSort.SortOld1(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueAscOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueDescOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueAscTwoSubarrayOneIsNullSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueDescTwoSubarrayOneIsNullNotSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueAscTwoSubarraysOneIsNullNotSortedTest()
        {
            int[][] arrayToSort = { null, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueDescTwoSubarraysOneIsNullNotSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueAscTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMaxValueDescTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.SortOld1(arrayToSort, By.MaxElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        #endregion tests for sorting by Max value

        #region sorting by Min value

        [Test]
        public void OldSortByMinValueAscTwoArraysWithOneElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { 2 } };
            BubbleSort.SortOld1(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void OldSortByMinValueDescTwoArraysWithOneElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { 2 } };
            int[][] arrayToSortExpected = { new int[] { 2 }, new int[] { 1 } };
            BubbleSort.SortOld1(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void OldSortByMinValueAscTwoArraysWithOneNegativeElementSortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { -2 }, new int[] { 1 } };
            BubbleSort.SortOld1(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void OldSortByMinValueDescTwoArraysWithOneNegativeElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { -2 }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { -2 } };
            BubbleSort.SortOld1(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void OldSortByMinValueAscTwoArraysWithOneMaxIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MaxValue } };
            BubbleSort.SortOld1(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void OldSortByMinValueDescTwoArraysWithOneMaxIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { int.MaxValue }, new int[] { 1 } };
            int[][] arrayToSortExpected = { new int[] { int.MaxValue }, new int[] { 1 } };
            BubbleSort.SortOld1(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void OldSortByMinValueAscTwoArraysWithOneMinIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { int.MinValue }, new int[] { 1 } };
            BubbleSort.SortOld1(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void OldSortByMinValueDescTwoArraysWithOneMinIntElementUnsortedTest()
        {
            int[][] arrayToSort = { new int[] { 1 }, new int[] { int.MinValue } };
            int[][] arrayToSortExpected = { new int[] { 1 }, new int[] { int.MinValue } };
            BubbleSort.SortOld1(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMinValueMsg);
        }

        [Test]
        public void OldSortByMinValueAscTwoArraysWithZeroedSubArraysUnsortedTest()
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
            BubbleSort.SortOld1(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMinValueDescTwoArraysWithZeroedSubArraysUnsortedTest()
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
            BubbleSort.SortOld1(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMinValueAscOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.SortOld1(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMinValueDescOneSubArrayWhichIsNullTest()
        {
            int[][] arrayToSort = { null };
            int[][] arrayToSortExpected = { null };
            BubbleSort.SortOld1(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMinValueAscTwoSubarrayOneIsNullNotSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.SortOld1(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMinValueDescTwoSubarrayOneIsNullSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.SortOld1(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMinValueAscTwoSubarraysOneIsNullSortedTest()
        {
            int[][] arrayToSort = { null, new int[] { 2 } };
            int[][] arrayToSortExpected = { null, new int[] { 2 } };
            BubbleSort.SortOld1(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMinValueDescTwoSubarraysOneIsNullSortedTest()
        {
            int[][] arrayToSort = { new int[] { 2 }, null };
            int[][] arrayToSortExpected = { new int[] { 2 }, null };
            BubbleSort.SortOld1(arrayToSort, By.MinElement, Direction.Descending);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void OldSortByMinValueAscTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.SortOld1(arrayToSort, By.MinElement);
            Assert.True(AreJaggedIntArraysEqual(arrayToSortExpected, arrayToSort), IncorrectSortByMaxValueMsg);
        }

        [Test]
        public void SortByMinValueDescTwoSubarraysWhichAreNullTest()
        {
            int[][] arrayToSort = { null, null };
            int[][] arrayToSortExpected = { null, null };
            BubbleSort.SortOld1(arrayToSort, By.MinElement, Direction.Descending);
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