using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static Task1.Solution.PasswordCheckerService;

namespace Task1.Solution.Tests
{
    [TestFixture]
    class VerifyPasswordTests
    {

        [Test]
        public void VerifyPassword_ContainsCatDog_True_Test()
        {
            PasswordValidator validators = new PasswordValidator(PasswordContainsCat);
            validators += PasswordContainsDog;

            IRepository rep = new SqlRepository();

            PasswordCheckerService service = new PasswordCheckerService(rep);

            Assert.True(service.VerifyPassword("catdog", validators).Item1);
        }

        [Test]
        public void VerifyPassword_ContainsCatDog_False_Test()
        {
            PasswordValidator validators = new PasswordValidator(PasswordContainsCat);
            validators += PasswordContainsDog;

            IRepository rep = new SqlRepository();

            PasswordCheckerService service = new PasswordCheckerService(rep);

            Assert.False(service.VerifyPassword("catdg", validators).Item1);
        }

        private bool PasswordContainsCat(string password)
        {
            return password.ToUpper().Contains("CAT");
        }

        private bool PasswordContainsDog(string password)
        {
            return password.ToUpper().Contains("DOG");
        }
    }
}