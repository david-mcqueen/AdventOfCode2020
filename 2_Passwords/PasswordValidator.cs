using _2_Passwords.Validators;
using System;
using System.Linq;
using Utilities;

namespace _2_Passwords
{
    public class PasswordValidator
    {
        private readonly IValidator validator;

        public PasswordValidator(IValidator validator)
        {
            this.validator = validator;
        }

        public int GetNumberOfValidPasswordsInFile(string filePath)
        {
            var inputs = FileReader.ReadFileLines(filePath);
            int validPasswords = 0;

            foreach (var item in inputs)
            {
                
                if (ValidatePassword(item))
                    validPasswords++;
            }

            return validPasswords;
        }

        public bool ValidatePassword(string input)
        {
            var password = getPasswordPart(input);
            var policy = getPasswordPolicy(input);
            return validator.IsPasswordValid(password.Trim(), policy);
        }        

        private string getPasswordPart(string input)
        {
            return input.Split(":").Last();
        }

        private PasswordPolicy getPasswordPolicy(string input)
        {
            var policy = input.Split(":").First();

            var parts = policy.Split(" ");
            var range = parts.First().Split("-");


            return new PasswordPolicy()
            {
                Character = parts.Last(),
                MinOccurance = int.TryParse(range.First(), out int minParsed) ? minParsed : 0,
                MaxOccurance = int.TryParse(range.Last(), out int maxParsed) ? maxParsed : 0
            };
        }
    }
}
