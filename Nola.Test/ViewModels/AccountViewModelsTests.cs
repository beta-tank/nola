﻿using System;
using System.Web.Mvc;
using FluentValidation.TestHelper;
using Moq;
using Nola.Core.Models.Education;
using Nola.Service.Services;
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
        private RegisterViewModelValidator<RegisterViewModel> validator;

        [SetUp]
        public void Setup()
        {
            validator = new RegisterViewModelValidator<RegisterViewModel>();
        }

        [Test]
        public void Name_Empty_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Name, null as string);
        }

        [Test]
        public void Name_ShortLength_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Name, "");
        }

        [Test]
        public void Name_LongLength_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Name, "12345123451234512345123451234512345123451");
        }

        [Test]
        public void Name_NormalLength_NotHaveErrors()
        {
            validator.ShouldNotHaveValidationErrorFor(model => model.Password, "abcdefgh");
        }

        [Test]
        public void Surname_Empty_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Surname, null as string);
        }

        [Test]
        public void Surname_ShortLength_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Surname, "");
        }

        [Test]
        public void Surname_LongLength_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Surname, "12345123451234512345123451234512345123451");
        }

        [Test]
        public void Surname_NormalLength_NotHaveErrors()
        {
            validator.ShouldNotHaveValidationErrorFor(model => model.Surname, "abcdefgh");
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

        [Test]
        public void SchioolId_Empty_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.SchoolId, 0);
        }

        [Test]
        public void SchioolId_Int_NotHaveErrors()
        {
            validator.ShouldNotHaveValidationErrorFor(model => model.SchoolId, 1);
        }

        [Test]
        public void TimeZoneId_Empty_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.TimeZoneId, 0);
        }

        [Test]
        public void TimeZoneId_Int_NotHaveErrors()
        {
            validator.ShouldNotHaveValidationErrorFor(model => model.TimeZoneId, 1);
        }
    }

    [TestFixture]
    public class RegisterStudentViewModelValidatorTests
    {
        private RegisterStudentViewModelValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new RegisterStudentViewModelValidator();
        }

        [Test]
        public void TeachingType_Empty_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor<RegisterStudentViewModel, TeachingType>(model => model.TeachingType, 0);
        }

        [Test]
        public void TeachingType_Int_NotHaveErrors()
        {
            validator.ShouldNotHaveValidationErrorFor(model => model.TeachingType, TeachingType.First);
        }

        [Test]
        public void Grade_Empty_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Grade, 0);
        }

        [Test]
        public void Grade_LessOne_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Grade, -1);
        }

        [Test]
        public void Grade_GratherTwelve_HaveErrors()
        {
            validator.ShouldHaveValidationErrorFor(model => model.Grade, 13);
        }

        [Test]
        public void Grade_Valid_NotHaveErrors()
        {
            validator.ShouldNotHaveValidationErrorFor(model => model.Grade, 1);
        }
    }
}
