using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomMath
{
    /// <summary>
    /// Handles polynomial expression of one variable; Polynom order is defined by the number of coefficients
    /// </summary>
    public class Polynom
    {
        #region public members

        public Polynom() : this(0.0)
        {
        }

        public Polynom(int coefficient)
        {
            Coefficients = new double[] { coefficient };

            Order = Coefficients.Length - 1;
        }

        public Polynom(params double[] coefficients)
        {
            Coefficients = coefficients;

            Order = Coefficients.Length - 1;
        }

        public int Order { get; private set; }

        public double[] Coefficients { get; private set; }

        public static Polynom operator +(Polynom p1, Polynom p2)
        {
            return new Polynom(0);
        }

        #endregion public members
    }
}