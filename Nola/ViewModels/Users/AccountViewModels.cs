using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Attributes;
using Nola.Core.Models.Education;
using Nola.Service.Services;

namespace Nola.ViewModels
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        public string Provider { get; set; }

        [Display(Name = "Код")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Запомнить этот браузер?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModelValidator : AbstractValidator<VerifyCodeViewModel>
    {
        public VerifyCodeViewModelValidator()
        {
            RuleFor(x => x.Provider).NotNull().WithMessage("Не указан провайдер авторизации");
            RuleFor(x => x.Code).NotNull().WithMessage("Не указан код авторизации");
        }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    [Validator(typeof(LoginViewModelValidator))]
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить на этом устройстве?")]
        public bool RememberMe { get; set; }
    }

    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Введите корректный {PropertyName}");
            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} не должен быть пустым").Length(6, 30).WithMessage("{PropertyName} должен быть от {MinLength} до {MaxLength} символов");
        }
    }

     [Validator(typeof(RegisterViewModelValidator<RegisterViewModel>))]
    public class RegisterViewModel
     {
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Школа")]
        public int SchoolId { get; set; }

        [Display(Name = "Часовой пояс")]
        public string TimeZoneId { get; set; }


        public SelectList SchoolsList { get; set; }
        public SelectList TimeZonesList { get; set; }
        public SelectList GradesList { get; set; }

        public RegisterViewModel()
        {           
            TimeZonesList = new SelectList(TimeZoneInfo.GetSystemTimeZones().Select(z => new { z.Id, z.DisplayName }), "Id", "DisplayName");
            GradesList = new SelectList(Enumerable.Range(1, 12));
        }

        public void PopulateSchoolsList(ISchoolService service)
        {
            SchoolsList = new SelectList(service.GetAll(), "Id", "Name");
        }

     }

    public class RegisterViewModelValidator<T> : AbstractValidator<T>  where T : RegisterViewModel
    {
        public RegisterViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Должно быть указано {PropertyName}").Length(1, 40).WithMessage("{PropertyName} должено быть от {MinLength} до {MaxLength} символов");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Должна быть указана {PropertyName}").Length(1, 40).WithMessage("{PropertyName} должена быть от {MinLength} до {MaxLength} символов");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Введите корректный {PropertyName}");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Должен быть указан {PropertyName}").Length(6, 30).WithMessage("{PropertyName} должен быть от {MinLength} до {MaxLength} символов");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Пароли не совпадают");
            RuleFor(x => x.SchoolId).NotEmpty().WithMessage("Должна быть указана {PropertyName}");
            RuleFor(x => x.TimeZoneId).NotEmpty().WithMessage("Должен быть указан {PropertyName}");
        }
    }

    [Validator(typeof (RegisterStudentViewModelValidator))]
    public class RegisterStudentViewModel : RegisterViewModel
    {
        [Display(Name = "Вид")]
        public TeachingType TeachingType { get; set; }

        [Display(Name = "Класс")]
        public int Grade { get; set; }
    }

    public class RegisterStudentViewModelValidator : RegisterViewModelValidator<RegisterStudentViewModel>
    {
        public RegisterStudentViewModelValidator()
        {
            RuleFor(x => x.TeachingType).NotNull().WithMessage("Должен быть указан {PropertyName}"); //TODO: поменять на int, или поправить правило
            RuleFor(x => x.Grade).NotEmpty().WithMessage("Должен быть указан {PropertyName}").InclusiveBetween(1, 12).WithMessage("{PropertyName} должен быть между 1 и 12");
        }
    }

    [Validator(typeof(RegisterTeacherViewModelValidator))]
    public class RegisterTeacherViewModel : RegisterViewModel
    {
        [Display(Name = "Преподаваемые предметы")]
        public ICollection<int> SubjectIds { get; set; }

        public SelectList SubjectsList { get; set; }

        public void PopulateSubjectsList(ISubjectService service)
        {
            SubjectsList = new SelectList(service.GetAll(), "Id", "Name");
        }

    }

    public class RegisterTeacherViewModelValidator : RegisterViewModelValidator<RegisterTeacherViewModel>
    {
        public RegisterTeacherViewModelValidator()
        {

        }
    }


    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
