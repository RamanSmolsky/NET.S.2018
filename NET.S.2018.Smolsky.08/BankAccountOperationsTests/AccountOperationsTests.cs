using BankAccountOperations;
using NUnit.Framework;

namespace BankAccountOperationsTests
{
    [TestFixture]
    public class AccountOperationsTests
    {
        private readonly string _balanceMismatchMsg = "balance is not equal to required amount, expected amount is";
        private readonly string _accumulatedBonusesMismatchMsg = "accumulated bonuses value is not equal to required amount";

        [Test]
        public void AddSomeAmountToBaseAccountTest()
        {
            CustomerPersonalData cust = new CustomerPersonalData("John", "Smith", 35);
            Account acc = new Account(1, AccountBenefitsType.Base, cust);
            decimal amount = 1000m;
            acc.Add(amount);
            ////TODO check if there is an existing NUnit method which wraps decimals comparisons
            Assert.That(decimal.Compare(acc.Balance, 1000m) == 0, $"{_balanceMismatchMsg} {amount}");
        }

        [Test]
        public void WithdrawSomeAmountFromBaseAccountTest()
        {
            CustomerPersonalData cust = new CustomerPersonalData("John", "Smith", 35);
            Account acc = new Account(1, AccountBenefitsType.Base, cust);
            decimal initialAmount = 1000m;
            acc.Add(initialAmount);
            decimal withdrawAmount = 600m;
            acc.Withdraw(withdrawAmount);
            decimal expectedAmount = 400m;
            ////TODO check if there is an existing NUnit method which wraps decimals comparisons
            Assert.That(decimal.Compare(acc.Balance, expectedAmount) == 0, $"{_balanceMismatchMsg} {expectedAmount}");
        }

        [Test]
        public void Bonuses_AddAmountToBaseAccount_CheckBonusesTest()
        {
            CustomerPersonalData cust = new CustomerPersonalData("John", "Smith", 35);
            Account acc = new Account(1, AccountBenefitsType.Base, cust);
            decimal amount = 1000m;
            acc.Add(amount);
            int expectedAccumulatedBonuses = 700;
            Assert.That(acc.AccumulatedBonuses, Is.EqualTo(expectedAccumulatedBonuses), $"{_accumulatedBonusesMismatchMsg}, expected: {expectedAccumulatedBonuses}, actual: {acc.AccumulatedBonuses}");
        }
    }
}
