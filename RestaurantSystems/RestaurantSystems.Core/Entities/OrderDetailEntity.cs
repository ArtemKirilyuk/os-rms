//  ***********************************************************************
//  <copyright file="OrderDetailEntity.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Core.Entities
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 19-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Core.Entities
{
    /// <summary>
    /// The order detail.
    /// </summary>
    public class OrderDetailEntity
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailEntity"/> class.
        /// </summary>
        public OrderDetailEntity()
        {
            this.Price = 0.0m;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets the spice type.
        /// </summary>
        public string SpiceType { get; set; }

        #endregion
    }
}