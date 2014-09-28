//  ***********************************************************************
//  <copyright file="OrderHeader.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.DataAccess
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 10-08-2014
//  ***********************************************************************
namespace RestaurantSystems.DataAccess.Model
{
    #region imports

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using RestaurantSystems.Core.Interfaces;

    #endregion

    /// <summary>
    /// The order header.
    /// </summary>
    public class OrderHeader : IEntity<int>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderHeader"/> class.
        /// </summary>
        public OrderHeader()
        {
            this.SubTotal = 0;
            this.Discount = 0;
            this.Total = 0;
            this.Cancelled = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the order type.
        /// </summary>
        [ForeignKey("OrderTypeId")]
        public OrderType OrderType { get; set; }

        /// <summary>
        /// Gets or sets the order type id.
        /// </summary>
        public int OrderTypeId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether cancelled.
        /// </summary>
        public bool Cancelled { get; set; }

        /// <summary>
        /// Gets or sets the sub total.
        /// </summary>
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        [MaxLength(300)]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion
    }
}