//  *********************************************************************************************************************
//  <copyright file="SendCodeViewModel.cs" company="Abdul Aziz">
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
    using System.Web.Mvc;

    #endregion

    /// <summary>
    ///     The send code view model.
    /// </summary>
    public class SendCodeViewModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the selected provider.
        /// </summary>
        public string SelectedProvider { get; set; }

        /// <summary>
        ///     Gets or sets the providers.
        /// </summary>
        public ICollection<SelectListItem> Providers { get; set; }

        /// <summary>
        ///     Gets or sets the return url.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether remember me.
        /// </summary>
        public bool RememberMe { get; set; }

        #endregion
    }
}