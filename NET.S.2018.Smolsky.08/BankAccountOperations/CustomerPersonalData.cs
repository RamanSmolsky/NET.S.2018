using System;
using System.Collections.Generic;

namespace BankAccountOperations
{
    /// <summary>
    /// Personal data of the customer
    /// </summary>
    public class CustomerPersonalData
    {
        public static readonly int AgeLowerLimit = 18;
        public static readonly int AgeUpperLimit = 99;
        public static readonly int NameLengthLimit = 50;

        public CustomerPersonalData(string firstName, string secondName, int age)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(secondName))
            {
                throw new ArgumentNullException($"{nameof(firstName)} and {nameof(secondName)} should not be null or empty");
            }

            if ((age < AgeLowerLimit) || (age > AgeUpperLimit))
            {
                throw new ArgumentOutOfRangeException($"{nameof(age)} should be above {AgeLowerLimit} and below {AgeUpperLimit}");
            }

            if (firstName.Length > NameLengthLimit && secondName.Length > NameLengthLimit)
            {
                throw new ArgumentOutOfRangeException($"{nameof(firstName)} and {nameof(secondName)} should not exceed limit of {NameLengthLimit} each");
            }

            FirstName = string.Copy(firstName);
            SecondName = string.Copy(secondName);
            Age = age;
        }

        /// <summary>
        /// First name of the customer
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Second name of the customer
        /// </summary>
        public string SecondName { get; private set; }

        /// <summary>
        /// Age of the customer
        /// </summary>
        public int Age { get; private set; }

        /// <summary>
        /// Creates a full copy of <see cref="CustomerPersonalData"/> object
        /// </summary>
        /// <param name="custData"></param>
        /// <returns>new instance of <see cref="CustomerPersonalData"/></returns>
        public static CustomerPersonalData Copy(CustomerPersonalData custData)
        {
            if (custData == null)
            {
                throw new ArgumentNullException($"{custData} shoud not be null");
            }

            return new CustomerPersonalData(custData.FirstName, custData.SecondName, custData.Age);
        }

        /// <summary>
        /// Compares instance of CustomerPersonalData object with another one
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if customer data in both objects are equal, false otherwise</returns>
        public override bool Equals(object obj)
        {
            var data = obj as CustomerPersonalData;
            return data != null &&
                   FirstName == data.FirstName &&
                   SecondName == data.SecondName &&
                   Age == data.Age;
        }

        /// <summary>
        /// Returns hash code for this instance of customer data
        /// </summary>
        /// <returns>int representin hashcode of object instance data</returns>
        public override int GetHashCode()
        {
            var hashCode = 744496548;
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = (hashCode * -1521134295) + EqualityComparer<string>.Default.GetHashCode(SecondName);
            hashCode = (hashCode * -1521134295) + Age.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Returns name of the customer in the form of 'First Name + Second Name'
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{FirstName} {SecondName}";
        }
    }
}