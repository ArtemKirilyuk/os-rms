//  *********************************************************************************************************************
//  <copyright file="LoginViewModel.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 08-09-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 08-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Web.UI.Models
{
    #region imports

    using System.ComponentModel.DataAnnotations;

    #endregion

    /// <summary>
    /// The login view model.
    /// </summary>
    public class LoginViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether remember me.
        /// </summary>
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        #endregion
    }
}