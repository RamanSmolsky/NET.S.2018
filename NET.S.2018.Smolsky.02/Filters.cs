using System;
using System.Collections.Generic;

namespace ArrayFilters
{
    /// <summary>
    /// Provides functionality to filter arrays using different conditions
    /// </summary>
    public class Filters
    {
        private static readonly int Base10 = 10;
        private static readonly int NumOfBase10Digits = 9;

        /// <summary>
        /// Filters given array of int using provided digit - elemens with this digit are left, without - discarded
        /// </summary>
        /// <param name="filter">digit to be used as a filter for array elements</param>
        /// <param name="sourceArray">source array of integers to be filtered</param>
        /// <returns>array of elements which contains provided digit as their part</returns>
        public static int[] FilterDigits(int filter, params int[] sourceArray)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException($"{nameof(sourceArray)} should not be null");
            }

            int filterAbsValue = Math.Abs(filter);

            if (filterAbsValue > NumOfBase10Digits)
            {
                throw new ArgumentOutOfRangeException($"{nameof(filter)} should be within range of -9 .. 0 .. 9");
            }

            List<int> tempList = new List<int>();

            foreach (var elem in sourceArray)
            {
                int elemAbsValue = Math.Abs(elem);

                if (elemAbsValue < Base10 && elemAbsValue != filterAbsValue)
                {
                    continue;
                }
                else if (elemAbsValue < Base10 && elemAbsValue == filterAbsValue)
                {
                    tempList.Add(elem);
                    continue;
                }

                int res = elemAbsValue;

                bool flag = true;

                while (flag)
                {
                    int reminderDivByTen = res % Base10;

                    if (reminderDivByTen == filterAbsValue)
                    {
                        tempList.Add(elem);
                        break;
                    }

                    res = (res - (res % Base10)) / Base10;

                    if (res == 0)
                    {
                        flag = false;
                    }
                }
            }

            return tempList.ToArray();
        }

        /// <summary>
        /// Filters given array of int using provided digit - elemens with this digit are left, without - discarded
        /// </summary>
        /// <param name="filter">digit to be used as a filter for array elements</param>
        //// TODO: give description for the predicate parameter
        /// <param name="predicate"></param>
        /// <param name="sourceArray">source array of integers to be filtered</param>
        /// <returns>array of elements which contains provided digit as their part</returns>
        //// TODO: update description
        public static int[] FilterByPredicate(IFilterInt filter, params int[] sourceArray)
        {
            if (filter == null)
            {
                throw new ArgumentNullException($"{nameof(filter)} filter-predicate should not be null");
            }

            if (sourceArray == null)
            {
                throw new ArgumentNullException($"{nameof(sourceArray)} should not be null");
            }

            List<int> tempList = new List<int>();

            foreach (var elem in sourceArray)
            {
                if (filter.ShouldBeIncluded(elem))
                {
                    tempList.Add(elem);
                }
            }

            return tempList.ToArray();
        }
    }
}