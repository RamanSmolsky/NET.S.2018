using System;

namespace ArrayFilters
{
    /// <summary>
    /// Provides functionality to check if particular integer contains provided one-digit 'filter' or not
    /// </summary>
    public class FilterByDigit : IFilterInt
    {
        private static readonly int Base10 = 10;
        private static readonly int NumOfBase10Digits = 9;

        public FilterByDigit(int digitToSearchFor)
        {
            if (Math.Abs(digitToSearchFor) > NumOfBase10Digits)
            {
                throw new ArgumentOutOfRangeException($"{nameof(digitToSearchFor)} should be within '- 9 ... 0 ... 9' range");
            }

            DigitToSearchFor = digitToSearchFor;
        }

        /// <summary>
        /// One-symbol integer digit from the '-9 ... 0 ... 9' range to be searched in another integer
        /// </summary>
        public int DigitToSearchFor { get; set; }

        public bool ShouldBeIncluded(int elementToCheck)
        {
            int filterAbsValue = Math.Abs(DigitToSearchFor);

            int elemAbsValue = Math.Abs(elementToCheck);

            if (elemAbsValue < Base10 && elemAbsValue != filterAbsValue)
            {
                return false;
            }
            else if (elemAbsValue < Base10 && elemAbsValue == filterAbsValue)
            {
                return true;
            }

            int res = elemAbsValue;

            bool flag = true;

            while (flag)
            {
                int reminderDivByTen = res % Base10;

                if (reminderDivByTen == filterAbsValue)
                {
                    return true;
                }

                res = (res - (res % Base10)) / Base10;

                if (res == 0)
                {
                    flag = false;
                }
            }

            return false;
        }
    }
}
