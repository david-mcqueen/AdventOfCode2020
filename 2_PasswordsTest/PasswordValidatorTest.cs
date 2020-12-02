using _2_Passwords;
using NUnit.Framework;

namespace _2_PasswordsTest
{
    public class PasswordValidatorTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("1-3 a: abcde", true)]
        [TestCase("1-3 b: cdefg", false)]
        [TestCase("2-9 c: ccccccccc", true)]
        public void Test1(string input, bool isValid)
        {
            var pwdValidator = new PasswordValidator();

            Assert.AreEqual(isValid, pwdValidator.IsPasswordValid(input));
        }
    }
}