//  ***********************************************************************
//  <copyright file="Booking.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.DataAccess
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 15-08-2014
//  ***********************************************************************
namespace RestaurantSystems.DataAccess.Model
{
    #region imports

    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using RestaurantSystems.Core.Interfaces;

    #endregion

    /// <summary>
    /// The booking.
    /// </summary>
    public class Booking : IEntity<int>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Booking"/> class.
        /// </summary>
        public Booking()
        {
            this.Cancelled = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

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
        /// Gets or sets the booking type.
        /// </summary>
        [ForeignKey("BookingTypeId")]
        public BookingType BookingType { get; set; }

        /// <summary>
        /// Gets or sets the booking type id.
        /// </summary>
        public int BookingTypeId { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Gets or sets the till.
        /// </summary>
        public DateTime Till { get; set; }

        /// <summary>
        /// Gets or sets the requested at.
        /// </summary>
        public DateTime RequestedOn { get; set; }

        /// <summary>
        /// Gets or sets the number of people.
        /// Number of people.
        /// </summary>
        public int ForPeople { get; set; }

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