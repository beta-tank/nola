using System;
using FluentValidation.TestHelper;
using Nola.ViewModels;
using NUnit.Framework;

namespace Nola.Test.ViewModelsTests
{
    [TestFixture]
    public class LoginViewModelValidatorTest
    {
        private  LoginViewModelValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new LoginViewModelValidator();
        }

        [Test]
        public void Email_Valid_NotHaveErrors()
        {
            validator.ShouldNotHaveValidationErrorFor(model => model.Email, "test@test.com");
        }

        [Test]
        public void Email_NotValid_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Email, "testtest.com");
        }

        [Test]
        public void Password_Empty_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Password, null as string);
        }

        [Test]
        public void Password_ShortLength_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Password, "12345");
        }

        [Test]
        public void Password_LongLength_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Password, "abcdefghijklmnopqrstuvwxyz12345");
        }

        [Test]
        public void Password_NormalLength_NotHaveErrors()
        {
            validator.ShouldNotHaveValidationErrorFor(model => model.Password, "abcdefgh");
        }
    }
}
