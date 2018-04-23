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

        [Test]
        public void VerifyPassword_IEnumerable_ContainsCatDog_True_Test()
        {
            List<IPasswordValidator> validators = new List<IPasswordValidator>()
            {
                new PasswordShouldContainCat(),
                new PasswordShouldContainDog()
            };

            IRepository rep = new SqlRepository();

            PasswordCheckerService service = new PasswordCheckerService(rep);

            var result = service.VerifyPassword("catdog", validators);

            Assert.True(result.Item1, result.Item2);
        }

        [Test]
        public void VerifyPassword_IEnumerable_ContainsCatDog_False_Test()
        {
            List<IPasswordValidator> validators = new List<IPasswordValidator>()
            {
                new PasswordShouldContainCat(),
                new PasswordShouldContainDog()
            };

            IRepository rep = new SqlRepository();

            PasswordCheckerService service = new PasswordCheckerService(rep);

            var result = service.VerifyPassword("catdg", validators);

            Assert.False(result.Item1, result.Item2);
        }


        private bool PasswordContainsCat(string password)
        {
            return password.ToUpper().Contains("CAT");
        }

        private bool PasswordContainsDog(string password)
        {
            return password.ToUpper().Contains("DOG");
        }

        private class PasswordShouldContainCat : IPasswordValidator
        {
            public Tuple<bool, string> VerifyPassword(string password)
            {
                bool res = password.ToUpper().Contains("CAT");
                string msg = res ? "Should contain 'Dog' rule is passed" : "Should contain 'Dog' is violated";
                return Tuple.Create(res, msg);
            }
        }

        private class PasswordShouldContainDog : IPasswordValidator
        {
            public Tuple<bool, string> VerifyPassword(string password)
            {
                bool res = password.ToUpper().Contains("DOG");
                string msg = res ? "Should contain 'Dog' rule is passed" : "Should contain 'Dog' is violated";
                return Tuple.Create(res, msg);
            }
        }

    }
}