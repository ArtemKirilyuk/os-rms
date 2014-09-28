//  ***********************************************************************
//  <copyright file="BookingEntity.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Core.Entities
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 13-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Core.Entities
{
    #region imports

    using System;

    #endregion

    /// <summary>
    /// The booking.
    /// </summary>
    public class BookingEntity
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingEntity"/> class.
        /// </summary>
        public BookingEntity()
        {
            this.Cancelled = false;
            this.Confirmed = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the from.
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Gets or sets the till.
        /// </summary>
        public DateTime Till { get; set; }

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the table for.
        /// </summary>
        public int TableFor { get; set; }

        /// <summary>
        /// Gets or sets the address line 1.
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line 2.
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the postcode.
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone.
        /// </summary>
        public string Mobilephone { get; set; }

        /// <summary>
        /// Gets or sets the tele phone.
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether cancelled.
        /// </summary>
        public bool Cancelled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether confirmed.
        /// </summary>
        public bool Confirmed { get; set; }

        #endregion
    }
}