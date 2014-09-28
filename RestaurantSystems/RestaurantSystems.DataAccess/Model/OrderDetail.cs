//  ***********************************************************************
//  <copyright file="OrderDetail.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.DataAccess
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 17-08-2014
//  ***********************************************************************
namespace RestaurantSystems.DataAccess.Model
{
    #region imports

    using System.ComponentModel.DataAnnotations.Schema;

    using RestaurantSystems.Core.Interfaces;

    #endregion

    /// <summary>
    /// The order detail.
    /// </summary>
    public class OrderDetail : IEntity<int>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetail"/> class.
        /// </summary>
        public OrderDetail()
        {
            this.Price = 0.0m;
            this.Quantity = 1;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the order header.
        /// </summary>
        [ForeignKey("OrderHeaderId")]
        public OrderHeader OrderHeader { get; set; }

        /// <summary>
        /// Gets or sets the order header id.
        /// </summary>
        public int OrderHeaderId { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the spice type.
        /// </summary>
        public SpiceType SpiceType { get; set; }

        /// <summary>
        /// Gets or sets the spice type id.
        /// </summary>
        public int SpiceTypeId { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        public decimal Total { get; set; }

        #endregion
    }
}