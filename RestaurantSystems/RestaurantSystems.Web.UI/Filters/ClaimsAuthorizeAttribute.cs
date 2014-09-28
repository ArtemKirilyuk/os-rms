//  *********************************************************************************************************************
//  <copyright file="ClaimsAuthorizeAttribute.cs" company="Abdul Aziz">
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
namespace RestaurantSystems.Web.UI.Filters
{
    #region imports

    using System.Security.Claims;
    using System.Web;
    using System.Web.Mvc;

    #endregion

    /// <summary>
    ///     The claims authorize attribute.
    /// </summary>
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        #region Fields

        /// <summary>
        ///     The claim type.
        /// </summary>
        private readonly string claimType;

        /// <summary>
        ///     The claim value.
        /// </summary>
        private readonly string claimValue;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ClaimsAuthorizeAttribute" /> class.
        /// </summary>
        public ClaimsAuthorizeAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimsAuthorizeAttribute"/> class.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public ClaimsAuthorizeAttribute(string type, string value)
        {
            this.claimType = type;
            this.claimValue = value;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The on authorization.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //var user = HttpContext.Current.User as ClaimsPrincipal;

            //if (!filterContext.RequestContext.HttpContext.Request.IsAuthenticated)
            //{
            //    this.HandleUnauthorizedRequest(filterContext);
            //}

            //if (user != null && this.claimType != null && this.claimValue != null
            //    && user.HasClaim(this.claimType, this.claimValue))
            //{
            //    base.OnAuthorization(filterContext);
            //}
            //else
            //{
            //    this.HandleUnauthorizedRequest(filterContext);
            //}
        }

        #endregion
    }
}