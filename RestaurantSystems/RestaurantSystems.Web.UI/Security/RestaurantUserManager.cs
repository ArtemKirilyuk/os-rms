//  *********************************************************************************************************************
//  <copyright file="RestaurantUserManager.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 13-09-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 13-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Web.UI.Security
{
    #region imports

    using System;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;

    using RestaurantSystems.Core.User;
    using RestaurantSystems.Ioc;

    #endregion

    /// <summary>
    ///     The restaurant user manager.
    /// </summary>
    public class RestaurantUserManager : UserManager<User>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantUserManager"/> class.
        /// </summary>
        /// <param name="store">
        /// The store.
        /// </param>
        public RestaurantUserManager(IUserStore<User> store)
            : base(store)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="RestaurantUserManager"/>.
        /// </returns>
        public static RestaurantUserManager Create(
            IdentityFactoryOptions<RestaurantUserManager> options, 
            IOwinContext context)
        {
            var userStore = WebDependency.Resolve<IUserStore<User>>();

            var manager = new RestaurantUserManager(userStore);

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
                                        {
                                            AllowOnlyAlphanumericUserNames = false, 
                                            RequireUniqueEmail = true
                                        };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
                                            {
                                                RequiredLength = 6, 
                                                RequireNonLetterOrDigit = false, 
                                                RequireDigit = false, 
                                                RequireLowercase = false, 
                                                RequireUppercase = false, 
                                            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider(
                "Phone Code", 
                new PhoneNumberTokenProvider<User> { MessageFormat = "Your security code is {0}" });
            manager.RegisterTwoFactorProvider(
                "Email Code", 
                new EmailTokenProvider<User> { Subject = "Security Code", BodyFormat = "Your security code is {0}" });

            // manager.EmailService = new EmailService();
            // manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }

        #endregion
    }
}