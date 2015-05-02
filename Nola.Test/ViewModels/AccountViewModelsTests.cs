﻿using System;
using FluentValidation.TestHelper;
using Nola.ViewModels;
using NUnit.Framework;

namespace Nola.Test.ViewModelsTests
{
    [TestFixture]
    public class LoginViewModelValidatorTests
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

    [TestFixture]
    public class VerifyCodeViewModelValidatorTests
    {
        private VerifyCodeViewModelValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new VerifyCodeViewModelValidator();
        }

        [Test]
        public void Provider_Null_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Provider, null as string);
        }

        [Test]
        public void Provider_String_NotHaveErrors()
        {
            validator.ShouldNotHaveValidationErrorFor(model => model.Provider, "provider");
        }

        [Test]
        public void Code_Null_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Code, null as string);
        }

        [Test]
        public void Code_String_NotHaveErrors()
        {
            validator.ShouldNotHaveValidationErrorFor(model => model.Code, "code");
        }
    }

    [TestFixture]
    public class RegisterViewModelValidatorTests
    {
        private RegisterViewModelValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new RegisterViewModelValidator();
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

        [Test]
        public void ConfirmPassword_EqualsPassword_NotHaveErrors()
        {
            var password = "abcdefgh";
            var model = new RegisterViewModel() { Password = password , ConfirmPassword = password};
            validator.ShouldNotHaveValidationErrorFor(x => x.ConfirmPassword, model);
        }

        [Test]
        public void ConfirmPassword_NotEqualsPassword_HaveErrors()
        {
            var password = "abcdefgh";
            var model = new RegisterViewModel() { Password = password, ConfirmPassword = "123" };
            validator.ShouldHaveValidationErrorFor(x => x.ConfirmPassword, model);
        }
    }
}
