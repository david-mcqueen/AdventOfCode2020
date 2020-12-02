using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Passwords.Validators
{
    public interface IValidator
    {
        bool IsPasswordValid(string password, PasswordPolicy policy);
    }
}
