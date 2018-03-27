using BankAccountOperations;
using NUnit.Framework;

namespace BankAccountOperationsTests
{
    [TestFixture]
    public class AccountCreationTests
    {
        [Test]
        public void CreateEmptyBaseAccountTest()
        {
            CustomerPersonalData cust = new CustomerPersonalData("John", "Smith", 35);
            Account acc = new Account(1, AccountBenefitsType.Base, cust);
            Assert.That(acc.ID == 1 && acc.BenefitsType == AccountBenefitsType.Base);
        }
    }
}