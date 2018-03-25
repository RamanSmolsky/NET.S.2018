using NUnit.Framework;

using PolynomMath;

namespace PolynomMathTests
{
    [TestFixture]
    public class PolynomMathTestss
    {
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
    }
}