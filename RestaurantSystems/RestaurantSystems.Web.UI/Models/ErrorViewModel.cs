//  *********************************************************************************************************************
//  <copyright file="ErrorViewModel.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 07-09-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 07-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Web.UI.Models
{
    /// <summary>
    /// The error view model.
    /// </summary>
    public class ErrorViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the request url.
        /// </summary>
        public string RequestUrl { get; set; }

        #endregion
    }
}