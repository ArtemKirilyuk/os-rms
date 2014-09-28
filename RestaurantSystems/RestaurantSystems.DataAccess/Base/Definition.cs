//  ***********************************************************************
//  <copyright file="Definition.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.DataAccess
//   Author           : Abdul Aziz
//   Created          : 09-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 09-08-2014
//  ***********************************************************************
namespace RestaurantSystems.DataAccess.Base
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The definition.
    /// </summary>
    public class Definition
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        [MaxLength(3)]
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [MaxLength(300)]
        [Required]
        public string Description { get; set; }

        #endregion
    }
}