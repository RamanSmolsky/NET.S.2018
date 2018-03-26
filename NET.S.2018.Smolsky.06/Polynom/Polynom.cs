using System;
using System.Collections.Generic;

namespace PolynomMath
{
    /// <summary>
    /// Handles polynomial expression of one variable; Polynom order is defined by the number of coefficients
    /// </summary>
    public class Polynom
    {
        #region public members

        public const double AllowedDifferenceOnComparison = 0.0000000000000009;

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

        public static Polynom operator +(Polynom lhs, Polynom rhs)
        {
            if (lhs is null || rhs is null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} or {nameof(rhs)} or both are null");
            }
            ////TODO: check for overflow
            if (lhs.Order == rhs.Order)
            {
                double[] coefTemp = new double[lhs.Order];

                int numOfCoef = lhs.Coefficients.Length;

                for (int i = 0; i < numOfCoef - 1; i++)
                {
                    coefTemp[i] = lhs.Coefficients[i] + rhs.Coefficients[i];
                }

                return new Polynom(numOfCoef);
            }

            return AddSmallerPolynomToBigger(lhs, rhs);
        }

        public static bool operator ==(Polynom lhs, Polynom rhs)
        {
            if (lhs is null || rhs is null)
            {
                throw new ArgumentNullException($"{nameof(lhs)} or {nameof(rhs)} or both are null");
            }

            if (lhs.Order != rhs.Order)
            {
                return false;
            }

            return AreCoefficientsEqual(lhs.Coefficients, rhs.Coefficients);
        }

        public static bool operator !=(Polynom lhs, Polynom rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object obj)
        {
            var polynom = obj as Polynom;
            return !(polynom is null) &&
                   Order == polynom.Order &&
                   Coefficients.Length == polynom.Coefficients.Length &&
                   AreCoefficientsEqual(Coefficients, polynom.Coefficients);
        }

        public override int GetHashCode()
        {
            var hashCode = -113512862;
            hashCode = (hashCode * -1521134295) + Order.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<double[]>.Default.GetHashCode(Coefficients);
            return hashCode;
        }

        #endregion public members

        #region private members

        private static Polynom AddSmallerPolynomToBigger(Polynom smaller, Polynom bigger)
        {
            if (smaller is null || bigger is null)
            {
                throw new ArgumentNullException($"{nameof(smaller)} or {nameof(bigger)} or both are null");
            }

            if (smaller.Order < bigger.Order)
            {
                double[] coefTemp = new double[bigger.Coefficients.Length];
                int numOfElemInShorterPolynom = smaller.Coefficients.Length;
                int numOfElemInLongerPolynom = bigger.Coefficients.Length;                

                for (int i = 0; i < numOfElemInShorterPolynom; i++)
                {
                    coefTemp[i] = smaller.Coefficients[i] + bigger.Coefficients[i];
                }

                int remainedPart = numOfElemInLongerPolynom - (numOfElemInLongerPolynom - numOfElemInShorterPolynom);

                for (int i = remainedPart; i < numOfElemInLongerPolynom; i++)
                {
                    coefTemp[i] = bigger.Coefficients[i];
                }

                return new Polynom(coefTemp);
            }
            else
            {
                return AddSmallerPolynomToBigger(bigger, smaller);
            }            
        }

        private static bool AreCoefficientsEqual(double[] coefLhs, double[] coefRhs)
        {
            if (coefLhs is null || coefRhs is null)
            {
                throw new ArgumentNullException($"{nameof(coefLhs)} or {nameof(coefRhs)} or both are null");
            }

            if (coefLhs.Length != coefRhs.Length)
            {
                return false;
            }

            int numOfCoef = coefLhs.Length;

            for (int i = 0; i < numOfCoef - 1; i++)
            {
                if (Math.Abs(coefLhs[i] - coefRhs[i]) > AllowedDifferenceOnComparison)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion private members
    }
}