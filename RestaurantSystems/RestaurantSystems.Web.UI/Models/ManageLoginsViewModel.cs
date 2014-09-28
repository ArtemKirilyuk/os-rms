//  *********************************************************************************************************************
//  <copyright file="ManageLoginsViewModel.cs" company="Abdul Aziz">
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
namespace RestaurantSystems.Web.UI.Models
{
    #region imports

    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    #endregion

    /// <summary>
    ///     The manage logins view model.
    /// </summary>
    public class ManageLoginsViewModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the current logins.
        /// </summary>
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        /// <summary>
        ///     Gets or sets the other logins.
        /// </summary>
        public IList<AuthenticationDescription> OtherLogins { get; set; }

        #endregion
    }
}