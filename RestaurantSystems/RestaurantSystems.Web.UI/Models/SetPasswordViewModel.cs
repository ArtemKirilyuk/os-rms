//  *********************************************************************************************************************
//  <copyright file="SetPasswordViewModel.cs" company="Abdul Aziz">
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
    ///     The set password view model.
    /// </summary>
    public class SetPasswordViewModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the new password.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        /// <summary>
        ///     Gets or sets the confirm password.
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        #endregion
    }
}