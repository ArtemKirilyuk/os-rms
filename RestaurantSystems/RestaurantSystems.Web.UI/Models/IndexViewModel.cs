//  *********************************************************************************************************************
//  <copyright file="IndexViewModel.cs" company="Abdul Aziz">
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

    #endregion

    /// <summary>
    ///     The index view model.
    /// </summary>
    public class IndexViewModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets a value indicating whether has password.
        /// </summary>
        public bool HasPassword { get; set; }

        /// <summary>
        ///     Gets or sets the logins.
        /// </summary>
        public IList<UserLoginInfo> Logins { get; set; }

        /// <summary>
        ///     Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether two factor.
        /// </summary>
        public bool TwoFactor { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether browser remembered.
        /// </summary>
        public bool BrowserRemembered { get; set; }

        #endregion
    }
}