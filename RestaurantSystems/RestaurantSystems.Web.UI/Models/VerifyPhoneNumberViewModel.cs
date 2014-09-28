//  *********************************************************************************************************************
//  <copyright file="VerifyPhoneNumberViewModel.cs" company="Abdul Aziz">
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
    ///     The verify phone number view model.
    /// </summary>
    public class VerifyPhoneNumberViewModel
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        /// <summary>
        ///     Gets or sets the phone number.
        /// </summary>
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        #endregion
    }
}