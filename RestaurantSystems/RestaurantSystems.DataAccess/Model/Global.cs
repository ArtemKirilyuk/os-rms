//  ***********************************************************************
//  <copyright file="Global.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.DataAccess
//   Author           : Abdul Aziz
//   Created          : 10-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 10-08-2014
//  ***********************************************************************
namespace RestaurantSystems.DataAccess.Model
{
    #region imports

    using System.ComponentModel.DataAnnotations;

    using RestaurantSystems.Core.Interfaces;

    #endregion

    /// <summary>
    /// The global.
    /// </summary>
    public class Global : IEntity<int>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [Required]
        [MaxLength(2000)]
        public string Value { get; set; }

        #endregion
    }
}