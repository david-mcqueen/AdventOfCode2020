using _2_Passwords;
using _2_Passwords.Validators;
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
        public void GivenPasswordValidator_WhenPasswordIsProvided_ThenCorrectAnswerIsReturned(string input, bool isValid)
        {
            var pwdValidator = new PasswordValidator(new OccurenceValidator());

            Assert.AreEqual(isValid, pwdValidator.ValidatePassword(input));
        }

        [Test]
        public void GivenBulkPasswordValidator_WhenBulkPasswordsAreProvided_ThenCountOfCorrectPasswordsIsProvided()
        {
            var pwdValidator = new PasswordValidator(new OccurenceValidator());

            var count = pwdValidator.GetNumberOfValidPasswordsInFile("input.txt");

            Assert.AreEqual(580, count);
        }

        [TestCase("1-3 a: abcde", true)]
        [TestCase("1-3 b: cdefg", false)]
        [TestCase("2-9 c: ccccccccc", false)]
        public void GivenPositionValidator_WhenPasswordIsProvided_ThenCorrectAnswerIsReturned(string input, bool isValid)
        {
            var pwdValidator = new PasswordValidator(new PositionValidator());

            Assert.AreEqual(isValid, pwdValidator.ValidatePassword(input));
        }

        [Test]
        public void GivenPositionValidator_WhenBulkPasswordsAreProvided_ThenCountOfCorrectPasswordsIsProvided()
        {
            var pwdValidator = new PasswordValidator(new PositionValidator());

            var count = pwdValidator.GetNumberOfValidPasswordsInFile("input.txt");

            Assert.AreEqual(611, count);
        }
    }
}