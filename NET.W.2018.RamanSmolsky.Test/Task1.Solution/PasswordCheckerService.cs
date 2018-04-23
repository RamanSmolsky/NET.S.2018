using System;
using System.Linq;

namespace Task1.Solution
{
    public class PasswordCheckerService
    {
        public delegate bool PasswordValidator(string password);

        private IRepository _repository;

        public Tuple<bool, string> VerifyPassword(string password)
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            if (password == string.Empty)
                return Tuple.Create(false, $"{password} is empty ");

            // check if length more than 7 chars 
            if (password.Length <= 7)
                return Tuple.Create(false, $"{password} length too short");

            // check if length more than 10 chars for admins
            if (password.Length >= 15)
                return Tuple.Create(false, $"{password} length too long");

            // check if password conatins at least one alphabetical character 
            if (!password.Any(char.IsLetter))
                return Tuple.Create(false, $"{password} hasn't alphanumerical chars");

            // check if password conatins at least one digit character 
            if (!password.Any(char.IsNumber))
                return Tuple.Create(false, $"{password} hasn't digits");

            _repository.Create(password);

            return Tuple.Create(true, "Password is Ok. User was created");
        }

        public Tuple<bool, string> VerifyPassword(string password, PasswordValidator validator)
        {
            if (password == null)
                throw new ArgumentException($"{password} is null arg");

            if (password == string.Empty)
                return Tuple.Create(false, $"{password} is empty ");

            if (validator == null)
            {
                return VerifyPassword(password);
            }

            bool result = true;

            foreach (PasswordValidator rule in validator.GetInvocationList())
            {
                result &= rule(password);                
            }

            if (!result)
                return Tuple.Create(false, $"{password} is not valid");

            _repository.Create(password);

            return Tuple.Create(true, "Password is Ok. User was created");
        }

        public PasswordCheckerService(IRepository repository)
        {
            _repository = repository;
        }
    }
}