using GCDbyEuclidAlgorithm;
using NUnit.Framework;

namespace GCDbyDifferentAlgorithmsTests
{
    [TestFixture]
    public class GCDbyEuclidAlgorithmTests
    {
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(-1, ExpectedResult = 1)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(1, 2, ExpectedResult = 1)]
        [TestCase(2, 2, ExpectedResult = 2)]
        [TestCase(-2, 2, ExpectedResult = 2)]
        [TestCase(-2, -2, ExpectedResult = 2)]
        [TestCase(-2, -3, ExpectedResult = 1)]
        [TestCase(0, 5, ExpectedResult = 5)]
        [TestCase(15, 0, ExpectedResult = 15)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        [TestCase(5, 10, 15, ExpectedResult = 5)]
        [TestCase(11, 121, 1331, 14641, ExpectedResult = 11)]
        public int GcdOneAndOneTest(params int[] elements)
        {
            return GCD.CalculateGCD(elements);
        }
    }
}