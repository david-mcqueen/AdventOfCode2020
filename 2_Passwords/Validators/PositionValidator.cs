using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Passwords.Validators
{
    public class PositionValidator : IValidator
    {
        public bool IsPasswordValid(string password, PasswordPolicy policy)
        {
            var firstOccurenceValid = password[policy.MinOccurance - 1].ToString().Equals(policy.Character);
            var lastOccurenceValid = password[policy.MaxOccurance - 1].ToString().Equals(policy.Character);
            return firstOccurenceValid && !lastOccurenceValid || lastOccurenceValid && !firstOccurenceValid;
        }
    }
}
