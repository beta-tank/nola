using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Data;
using Nola.Core.Models.Users;

namespace Nola.Service.Identity
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser, int>
    {
        private ApplicationRoleManager roleManager;

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return roleManager;
            }
            private set
            {
                roleManager = value;
            }
        }


        public ApplicationUserManager(IApplicationUserStore store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new ApplicationUserStore(context.Get<ApplicationDbContext>()));
            manager.RoleManager =
                new ApplicationRoleManager(
                    new RoleStore<ApplicationRole, int, ApplicationUserRole>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser, int>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser, int>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, int>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            var userIdentity = base.CreateUserIdentityAsync(user);
            //var userIdentity = ((ApplicationUserManager)UserManager).CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
            var roles = ((ApplicationUserManager) UserManager).GetRoles(user.Id);
            userIdentity.Result.AddClaim(new Claim(System.Security.Claims.ClaimTypes.Sid, user.Id.ToString()));
            foreach (var role in roles)
            {
                userIdentity.Result.AddClaims(Mapper.Map<ICollection<ApplicationClaim>, ICollection<Claim>>(((ApplicationUserManager)UserManager).RoleManager.FindByName(role).Claims));
            }
            return userIdentity;
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
