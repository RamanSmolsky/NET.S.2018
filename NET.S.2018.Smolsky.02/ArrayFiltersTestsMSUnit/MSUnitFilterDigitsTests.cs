using ArrayFilters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayFiltersTestsMSUnit
{
    [TestClass]
    public class MSUnitFilterDigitsTests
    {
        private readonly string filteredArrayMismatchMsg = "filtered array is not as expected";

        [TestMethod]
        public void MSUnit_FilterDigits_OnePositiveElementOneMatch_Test()
        {
            int filter = 1;
            int[] expected = new[] { 111 };
            int[] actual = Filters.FilterDigits(filter, 111);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }

        [TestMethod]
        public void MSUnit_FilterDigits_FilterIsNegativeOneMatch_Test()
        {
            int filter = -1;
            int[] expected = new int[] { -1 };
            int[] actual = Filters.FilterDigits(filter, -1, 2);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }

        [TestMethod]
        public void MSUnit_FilterDigits_OnePositiveElementNoMatch_Test()
        {
            int filter = 1;
            int[] expected = new int[] { };
            int[] actual = Filters.FilterDigits(filter, 222);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }

        [TestMethod]
        public void MSUnit_FilterDigits_ZeroFilterOneElementMatch_Test()
        {
            int filter = 0;
            int[] expected = new int[] { 220 };
            int[] actual = Filters.FilterDigits(filter, 220);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }

        [TestMethod]
        public void MSUnit_FilterDigits_SetFromTaskExample_Test()
        {
            int filter = 7;
            int[] expected = new[] { 7, 7, 70, 17 };
            int[] actual = Filters.FilterDigits(filter, 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }
    }
}