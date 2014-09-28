//  *********************************************************************************************************************
//  <copyright file="BaseController.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 14-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 13-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Web.UI.Controllers
{
    #region imports

    using System;
    using System.Web.Mvc;

    using RestaurantSystems.Core.Manager;

    #endregion

    /// <summary>
    ///     The base controller.
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
        #region Fields

        /// <summary>
        ///     The security managemnt.
        /// </summary>
        protected readonly ISecurityManager SecurityManagemnt;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="securityManagemnt">
        /// The security store.
        /// </param>
        public BaseController(ISecurityManager securityManagemnt)
        {
            this.SecurityManagemnt = securityManagemnt;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on action executing.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var actionName = filterContext.ActionDescriptor.ActionName;

            if (
                !this.SecurityManagemnt.IsUserAllowedToAccess(
                    controllerName, 
                    actionName, 
                    filterContext.HttpContext.User.Identity.Name))
            {
                ThrowUnauthorised();
            }

            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        ///     The throw unauthorised.
        /// </summary>
        /// <exception cref="ApplicationException">
        ///     Throws application exception. this method is called when user is not authorised.
        /// </exception>
        private static void ThrowUnauthorised()
        {
            throw new ApplicationException(
                "You are not authorised to perform this action. Please contact IT Support if you think you should.");
        }

        #endregion
    }
}