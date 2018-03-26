using System;
using NUnit.Framework;

using PolynomMath;

namespace PolynomMathTests
{
    [TestFixture]
    public class PolynomMathAndMethodsTests
    {
        private const string RequiredExceptionNotThrownMsg = "exception of required type was not thrown";

        [Test]
        public void PolynomOfZeroOrderTest()
        {
            Polynom p = new Polynom();
            Assert.AreEqual(0, p.Order);
        }

        [Test]
        public void PolynomOfFirstOrderTest()
        {
            Polynom p = new Polynom(1, 2);
            Assert.AreEqual(1, p.Order);
        }

        [Test]
        public void PolynomsOfFirstOrderSumTest()
        {
            Polynom p1 = new Polynom(1);
            Polynom p2 = new Polynom(2);
            Polynom result = p1 + p2;
            Assert.AreEqual(0, result.Order);
        }

        [Test]
        public void PolynomOfFirstOrderEqualsToItselfTest()
        {
            Polynom p = new Polynom(1.000007, 2.000003);
            Assert.True(p.Equals(p), "polynom should be qual to itself");
        }

        [Test]
        public void PolynomOfFirstOrderIsNotEqualToZeroOrderPolynomTest()
        {
            Polynom p1 = new Polynom(1);
            Polynom p2 = new Polynom(1, 2);
            Assert.False(p1.Equals(p2), "polynoms should be not marked as not equal");
        }

        [Test]
        public void PolynomsLeftOperandInAdditionIsNullTest()
        {
            Polynom p1 = null;
            Polynom p2 = new Polynom(2);
            Polynom result;
            Assert.Catch(typeof(ArgumentNullException), () => { result = p1 + p2; }, RequiredExceptionNotThrownMsg);
        }

        [Test]
        public void PolynomsRightOperandInAdditionIsNullTest()
        {
            Polynom p1 = new Polynom(2);
            Polynom p2 = null;
            Polynom result;
            Assert.Catch(typeof(ArgumentNullException), () => { result = p1 + p2; }, RequiredExceptionNotThrownMsg);
        }

        [Test]
        public void SumOfZeroOrderPolynomsTest()
        {
            Polynom p1 = new Polynom(1);
            Polynom p2 = new Polynom(2);
            Polynom result = p1 + p2;
        }

        [Test]
        public void SumOfSecondOrderPolynomsTest()
        {
            Polynom p1 = new Polynom(1, 2, 3);
            Polynom p2 = new Polynom(1, 2, 3);
            Polynom resExpected = new Polynom(2, 4, 6);

            Polynom result = p1 + p2;                        
        }

        [Test]
        public void SumOfFirstAndSecondOrderPolynomsTest()
        {
            Polynom p1 = new Polynom(1, 2);
            Polynom p2 = new Polynom(1, 2, 3);
            Polynom resExpected = new Polynom(2, 4, 3);

            Polynom result = p1 + p2;
        }

        [Test]
        public void SumOfFirstAndSecondOrderPolynoms1Test()
        {
            Polynom resExpected = new Polynom(2.4, 4.8, 3.7);

            Polynom p1 = new Polynom(1.1, 2.3);
            Polynom p2 = new Polynom(1.3, 2.5, 3.7);
            Polynom result = p1 + p2;
            bool b = result == resExpected;
            Assert.True((p1 + p2) == resExpected, "add result is wrong");
        }

        ////TODO: test == operator, for equal, for not equal
        ////TODO: test != operator, for equal, for not equal
    }
}