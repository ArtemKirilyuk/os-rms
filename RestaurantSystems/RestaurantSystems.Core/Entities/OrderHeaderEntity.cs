//  ***********************************************************************
//  <copyright file="OrderHeaderEntity.cs" company="Abdul Aziz">
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
    #region imports

    using System;

    #endregion

    /// <summary>
    /// The order header.
    /// </summary>
    public class OrderHeaderEntity
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderHeaderEntity"/> class.
        /// </summary>
        public OrderHeaderEntity()
        {
            this.SubTotal = 0.0m;
            this.Discount = 0.0m;
            
            this.Total = 0.0m;
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
        /// Gets or sets the full name.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the address line 1.
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line 2.
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the post code.
        /// </summary>
        public string PostCode { get; set; }

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

        #endregion
    }
}