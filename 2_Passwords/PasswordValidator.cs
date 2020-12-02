using System;
using System.Linq;

namespace _2_Passwords
{
    public class PasswordValidator
    {
        public bool IsPasswordValid(string input)
        {
            var password = getPasswordPart(input);
            var policy = getPasswordPolicy(input);

            var occurences = password.Count(c => c.ToString().Equals(policy.Character));


            return occurences >= policy.MinOccurance && occurences <= policy.MaxOccurance;
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
