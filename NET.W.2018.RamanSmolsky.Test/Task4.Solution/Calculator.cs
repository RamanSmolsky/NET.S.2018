using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4.Solution
{
    public class Calculator
    {
        public delegate double AveragingMethod(List<double> values);

        public double CalculateAverage(List<double> values, ICalculateAverage averagingMethod)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            var res = averagingMethod.Calculate(values);

            return res;
        }

        public double CalculateAverage(List<double> values, AveragingMethod averagingMethod)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            var res = averagingMethod(values);

            return res;
        }
    }
}
