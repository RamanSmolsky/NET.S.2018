using System;
using Fibonacci;
using NUnit.Framework;

namespace FibonacciMathTests
{
    [TestFixture]
    public class FibonacciMathGetNumbersTests
    {
        [TestCase(1, ExpectedResult = new int[] { 1 })]
        [TestCase(2, ExpectedResult = new int[] { 1, 1 })]
        [TestCase(3, ExpectedResult = new int[] { 1, 1, 2 })]
        [TestCase(4, ExpectedResult = new int[] { 1, 1, 2, 3 })]
        public int[] FibonacciMathGetNumbersTest(int numberOfElements)
        {
            return FibonacciMath.GetFibonacciNumbers(numberOfElements);            
        }

        [TestCase(35)]
        [TestCase(44)]
        public void FibonacciMathGetNumbersBigSequenceTest(int numberOfElements)
        {
            int[] actual = FibonacciMath.GetFibonacciNumbers(numberOfElements);
            Assert.True(CheckIntArrayIsAFibonacciSequence(actual));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(35)]
        [TestCase(44)]
        public void FibonacciMathGetNumbersYeildTest(int numberOfElements)
        {
            int[] actual = new int[numberOfElements];
            int i = 0;

            foreach (var element in FibonacciMath.GetFibonacciNumbersYeild(numberOfElements))
            {
                actual[i++] = element;
            }

            Assert.True(CheckIntArrayIsAFibonacciSequence(actual));
        }

        #region private methods
        private bool CheckIntArrayIsAFibonacciSequence(int[] fibonacciSequence)
        {
            if (fibonacciSequence == null)
            {
                throw new ArgumentNullException($"{nameof(fibonacciSequence)} should not be null");
            }

            if (fibonacciSequence.Length == 1)
            {
                return fibonacciSequence[0] == 1;
            }

            if (fibonacciSequence.Length == 2)
            {
                return fibonacciSequence[0] == 1 & fibonacciSequence[1] == 1;
            }

            for (int i = 0; i < fibonacciSequence.Length - 2; i++)
            {
                if (fibonacciSequence[i + 2] != fibonacciSequence[i] + fibonacciSequence[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}