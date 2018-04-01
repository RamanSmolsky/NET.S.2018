using ArrayFilters;
using NUnit.Framework;

namespace ArrayFiltersTestsNUnit
{
    [TestFixture]
    public class NUnitFilterDigitsTests
    {
        private readonly string filteredArrayMismatchMsg = "filtered array is not as expected";

        #region Filter by digit directly
        [Test]
        public void NUnit_FilterDigits_OnePositiveElementOneMatch_Test()
        {
            int filter = 1;
            int[] expected = new[] { 111 };
            int[] actual = Filters.FilterDigits(filter, 111);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }

        [Test]
        public void NUnit_FilterDigits_FilterIsNegativeOneMatch_Test()
        {
            int filter = -1;
            int[] expected = new int[] { -1 };
            int[] actual = Filters.FilterDigits(filter, -1, 2);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }

        [Test]
        public void NUnit_FilterDigits_OnePositiveElementNoMatch_Test()
        {
            int filter = 1;
            int[] expected = new int[] { };
            int[] actual = Filters.FilterDigits(filter, 222);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }

        [Test]
        public void NUnit_FilterDigits_ZeroFilterOneElementMatch_Test()
        {
            int filter = 0;
            int[] expected = new int[] { 220 };
            int[] actual = Filters.FilterDigits(filter, 220);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }

        [Test]
        public void NUnit_FilterDigits_SetFromTaskExample_Test()
        {
            int filter = 7;
            int[] expected = new[] { 7, 7, 70, 17 };
            int[] actual = Filters.FilterDigits(filter, 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }
        #endregion Filter by digit directly

        #region Filter by digit using predicate
        [Test]
        public void NUnit_FilterByPredicate_OnePositiveElementOneMatch_Test()
        {
            FilterByDigit filter = new FilterByDigit(1);
            int[] expected = new[] { 111 };
            int[] actual = Filters.FilterByPredicate(filter, 111);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }

        [Test]
        public void NUnit_FilterByPredicate_FilterIsNegativeOneMatch_Test()
        {
            FilterByDigit filter = new FilterByDigit(-1);
            int[] expected = new int[] { -1 };
            int[] actual = Filters.FilterByPredicate(filter, -1, 2);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }

        [Test]
        public void NUnit_FilterByPredicate_OnePositiveElementNoMatch_Test()
        {
            FilterByDigit filter = new FilterByDigit(1);
            int[] expected = new int[] { };
            int[] actual = Filters.FilterByPredicate(filter, 222);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }

        [Test]
        public void NUnit_FilterByPredicate_ZeroFilterOneElementMatch_Test()
        {
            FilterByDigit filter = new FilterByDigit(0);
            int[] expected = new int[] { 220 };
            int[] actual = Filters.FilterByPredicate(filter, 220);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }

        [Test]
        public void NUnit_FilterByPredicate_SetFromTaskExample_Test()
        {
            FilterByDigit filter = new FilterByDigit(7);
            int[] expected = new[] { 7, 7, 70, 17 };
            int[] actual = Filters.FilterByPredicate(filter, 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17);
            CollectionAssert.AreEqual(expected, actual, filteredArrayMismatchMsg);
        }
        #endregion Filter by digit using predicate
    }
}