using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2_Passwords.Validators
{
    public class OccurenceValidator: IValidator
    {
        public bool IsPasswordValid(string password, PasswordPolicy policy)
        {
            var occurences = password.Count(c => c.ToString().Equals(policy.Character));
            return occurences >= policy.MinOccurance && occurences <= policy.MaxOccurance;
        }
    }
}
