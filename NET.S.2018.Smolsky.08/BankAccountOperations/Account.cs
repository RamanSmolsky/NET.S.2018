using System;
using System.Collections.Generic;

namespace BankAccountOperations
{
    /// <summary>
    /// Provides list of possible account benefit types (Base, Silver, etc.)
    /// </summary>
    public enum AccountBenefitsType
    {
        Base,
        Silver,
        Gold,
        Platinum
    }

    /// <summary>
    /// Provides list of possible account states (e.g. Open, Closed)
    /// </summary>
    public enum StateType
    {
        Open,
        Closed
    }

    /// <summary>
    /// Keeps information about customers account, some personal information about the owner; performs operations on account
    /// </summary>
    public sealed class Account
    {
        private int _accumulatedBonuses;

        public Account(int id, AccountBenefitsType benefitsType, CustomerPersonalData cust)
        {
            if (cust == null)
            {
                throw new ArgumentNullException($"{nameof(cust)} should not be null");
            }

            ID = id;
            BenefitsType = benefitsType;
            State = StateType.Open;
            Owner = CustomerPersonalData.Copy(cust);
            Balance = decimal.Zero;
            AccumulatedBonuses = 0;
        }

        /// <summary>
        /// ID of the account as defined by other systems and provided during account creation
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Keeps account balance
        /// </summary>
        public decimal Balance { get; private set; }

        /// <summary>
        /// Benefits accumulated based on operations on this account, according to <see cref="AccountBenefitsType"/> and <see cref="BonusCoefficients"/>
        /// </summary>
        public AccountBenefitsType BenefitsType { get; private set; }

        /// <summary>
        /// Current state of the account
        /// </summary>
        public StateType State { get; private set; }

        /// <summary>
        /// Personal data of the account owner
        /// </summary>
        public CustomerPersonalData Owner { get; private set; }

        public int AccumulatedBonuses
        {
            get
            {
                return _accumulatedBonuses;
            }

            private set
            {
                _accumulatedBonuses = value;
                ////TODO: need to set limits on bonuses accumulation, as int is smaller then decimal
                ////TODO: check for possible exceptions when exceeding int.MinValue, int.MaxValue
            }
        }

        /// <summary>
        /// Returns True if account is in Open state, False - if its state is Closed (no operations are allowed)
        /// </summary>
        /// <returns>true (account is in Open state) or false (account is in Closed state)</returns>
        public bool IsAccountClosed()
        {
            return State == StateType.Closed;
        }

        /// <summary>
        /// Withdraws amount from the account if it is possible and account is in Open state
        /// </summary>
        /// <param name="amount"></param>
        public bool Withdraw(decimal amount)
        {
            if (State == StateType.Closed)
            {
                return false;
            }

            if (amount < decimal.Zero)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amount)} should be positive");
            }

            if (decimal.Compare(decimal.Zero + amount, Balance) == 1)
            {
                return false;
            }

            Balance -= amount;
            ////TODO need to check for exceeding int limits
            AccumulatedBonuses -= (int)Math.Round(amount * BonusCoefficients.WithdrawalBonuses[BenefitsType]);

            return true;
        }

        /// <summary>
        /// Adds provided amount to the account Balance if it is possible and account is in Open state
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>true if operation was OK, false otherwise</returns>
        public bool Add(decimal amount)
        {
            if (State == StateType.Closed)
            {
                return false;
            }

            if (amount < decimal.Zero)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amount)} should be positive");
            }

            if (decimal.Compare(decimal.MaxValue - amount, Balance) == -1)
            {
                return false;
            }

            Balance += amount;
            ////TODO need to check for exceeding int limits
            AccumulatedBonuses += (int)Math.Round(amount * BonusCoefficients.AddingBonuses[BenefitsType]);

            return true;
        }

        /// <summary>
        /// Moves account to closed state if it is possible, returns true in this case; false - if account could not be closed
        /// </summary>
        /// <returns>true if account could be closed, false otherwise</returns>
        public bool MoveToClosedState()
        {
            if (Balance == decimal.Zero)
            {
                State = StateType.Closed;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Provides hash code for the given account state. Does not include Balance amount in hash calculation
        /// </summary>
        /// <returns>int</returns>
        public override int GetHashCode()
        {
            ////TODO: check if this set is OK for HashCode purposes (do not include Balance)
            var hashCode = 2027537019;
            hashCode = (hashCode * -1521134295) + ID.GetHashCode();
            hashCode = (hashCode * -1521134295) + BenefitsType.GetHashCode();
            hashCode = (hashCode * -1521134295) + State.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Check accounts for equality 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            ////TODO: add Balance comparison (?), check for other properties possible states
            var account = obj as Account;
            return account != null &&
                   ID == account.ID &&
                   BenefitsType == account.BenefitsType &&
                   State == account.State &&
                   EqualityComparer<CustomerPersonalData>.Default.Equals(Owner, account.Owner);
        }

        /// <summary>
        /// Returns string representing account data (except Balance)
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"ID : {ID.ToString()} Type : {BenefitsType.ToString()} State: {State.ToString()} : Owner {Owner.ToString()}";
        }
    }
}