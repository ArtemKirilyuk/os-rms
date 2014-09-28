//  *********************************************************************************************************************
//  <copyright file="RestaurantSignInManager.cs" company="Abdul Aziz">
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

    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;

    using RestaurantSystems.Core.User;

    #endregion

    /// <summary>
    ///     The restaurant sign in manager.
    /// </summary>
    public class RestaurantSignInManager : SignInManager<User, string>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantSignInManager"/> class.
        ///     Constructor
        /// </summary>
        /// <param name="userManager">
        /// user manager
        /// </param>
        /// <param name="authenticationManager">
        /// authentication manager
        /// </param>
        public RestaurantSignInManager(
            UserManager<User, string> userManager, 
            IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
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
        /// The <see cref="RestaurantSignInManager"/>.
        /// </returns>
        public static RestaurantSignInManager Create(
            IdentityFactoryOptions<RestaurantSignInManager> options, 
            IOwinContext context)
        {
            return new RestaurantSignInManager(context.GetUserManager<RestaurantUserManager>(), context.Authentication);
        }

        /// <summary>
        /// The create user identity async.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return this.UserManager.CreateIdentityAsync(user, this.AuthenticationType);
        }

        #endregion
    }
}