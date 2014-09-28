//  ***********************************************************************
//  <copyright file="ProductCategory.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.DataAccess
//   Author           : Abdul Aziz
//   Created          : 09-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 30-08-2014
//  ***********************************************************************
namespace RestaurantSystems.DataAccess.Model
{
    #region imports

    using System.ComponentModel.DataAnnotations;

    using RestaurantSystems.Core.Interfaces;

    #endregion

    /// <summary>
    /// The product category.
    /// </summary>
    public class ProductCategory : IEntity<int>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [MaxLength(300)]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether removed.
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        public byte[] Image { get; set; }

        #endregion
    }
}