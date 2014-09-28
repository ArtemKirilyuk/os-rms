﻿//  ***********************************************************************
//  <copyright file="ProductLine.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Core.Entities
//   Author           : Abdul Aziz
//   Created          : 17-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 17-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Core.Entities
{
    /// <summary>
    /// The product view model.
    /// </summary>
    public class ProductLine
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// -1 - DISCOUNT
        /// -2 - TOTAL
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the spice.
        /// </summary>
        public int Spice { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        public decimal Total { get; set; }

        #endregion
    }
}