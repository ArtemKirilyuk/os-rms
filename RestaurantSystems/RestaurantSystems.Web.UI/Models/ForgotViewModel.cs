//  *********************************************************************************************************************
//  <copyright file="ForgotViewModel.cs" company="Abdul Aziz">
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

    using System.ComponentModel.DataAnnotations;

    #endregion

    /// <summary>
    ///     The forgot view model.
    /// </summary>
    public class ForgotViewModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        #endregion
    }
}