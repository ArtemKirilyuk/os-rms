//  *********************************************************************************************************************
//  <copyright file="RestaurantFeatureService.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Main
//   Author           : Abdul Aziz
//   Created          : 13-09-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 13-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Main.Service
{
    #region imports

    using System;
    using System.Collections.Generic;

    using RestaurantSystems.Core.Entities;
    using RestaurantSystems.Core.Exceptions;
    using RestaurantSystems.Core.Manager;
    using RestaurantSystems.Core.Repository;
    using RestaurantSystems.Core.Services;

    #endregion

    /// <summary>
    /// The restaurant management.
    /// </summary>
    public class RestaurantFeatureService : IRestaurantFeatureService
    {
        #region Fields

        /// <summary>
        /// The booking management.
        /// </summary>
        private readonly IBookingManagement bookingManagement;

        /// <summary>
        /// The email service.
        /// </summary>
        private readonly IEmailService emailService;

        /// <summary>
        /// The text service.
        /// </summary>
        private readonly ITextService textService;

        /// <summary>
        /// The receipt service.
        /// </summary>
        private readonly IReceiptService receiptService;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantFeatureService"/> class.
        /// </summary>
        public RestaurantFeatureService()
        {
            this.bookingManagement = GetInstance(this.bookingManagement);
            this.emailService = GetInstance(this.emailService);
            this.textService = GetInstance(this.textService);
            this.receiptService = GetInstance(this.receiptService);
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The cancel booking.
        /// </summary>
        /// <param name="bookingId">
        /// The booking id.
        /// </param>
        public void CancelBooking(int bookingId)
        {
            ThrowIfFeatureNotSupported(this.bookingManagement);

            this.bookingManagement.CancelBooking(bookingId);
        }

        /// <summary>
        /// The confirm booking.
        /// </summary>
        /// <param name="bookingId">
        /// The booking id.
        /// </param>
        public void ConfirmBooking(int bookingId)
        {
            ThrowIfFeatureNotSupported(this.bookingManagement);

            this.bookingManagement.ConfirmBooking(bookingId);
        }

        /// <summary>
        /// The create booking.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="till">
        /// The till.
        /// </param>
        /// <param name="forCustomerId">
        /// The for customer id.
        /// </param>
        /// <param name="forPeople">
        /// The for people.
        /// </param>
        public void CreateBooking(DateTime @from, DateTime till, int forCustomerId, int forPeople)
        {
            ThrowIfFeatureNotSupported(this.bookingManagement);

            this.bookingManagement.CreateBooking(@from, till, forCustomerId, forPeople);
        }

        /// <summary>
        /// The get booking.
        /// </summary>
        /// <param name="customerId">
        /// The customer id.
        /// </param>
        /// <param name="bookingId">
        /// The booking id.
        /// </param>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="till">
        /// The till.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<BookingEntity> GetBooking(int? customerId, int? bookingId, DateTime? @from, DateTime? till)
        {
            ThrowIfFeatureNotSupported(this.bookingManagement);

            return this.bookingManagement.GetBooking(customerId, bookingId, from, till);
        }

        /// <summary>
        /// The move booking.
        /// </summary>
        /// <param name="bookingId">
        /// The booking id.
        /// </param>
        /// <param name="startDate">
        /// The start date.
        /// </param>
        /// <param name="endDate">
        /// The end date.
        /// </param>
        public void MoveBooking(int bookingId, DateTime startDate, DateTime endDate)
        {
            ThrowIfFeatureNotSupported(this.bookingManagement);

            this.bookingManagement.MoveBooking(bookingId, startDate, endDate);
        }

        /// <summary>
        /// The search.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public IEnumerable<BookingEntity> Search(DateTime? @from, string customer)
        {
            ThrowIfFeatureNotSupported(this.bookingManagement);

            return this.bookingManagement.Search(from, customer);
        }

        /// <summary>
        /// The update booking.
        /// </summary>
        /// <param name="bookingId">
        /// The booking id.
        /// </param>
        /// <param name="forPeople">
        /// The for people.
        /// </param>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="till">
        /// The till.
        /// </param>
        public void UpdateBooking(int bookingId, int forPeople, DateTime from, DateTime till)
        {
            ThrowIfFeatureNotSupported(this.bookingManagement);

            this.bookingManagement.UpdateBooking(bookingId, forPeople, from, till);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T">
        /// Any class
        /// </typeparam>
        /// <param name="type">
        /// Any instance or class
        /// </param>
        /// <returns>
        /// Instance of implementation of type T
        /// </returns>
        private static T GetInstance<T>(T type) where T : class
        {
            return null;
        }

        /// <summary>
        /// The check for license.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <typeparam name="T">
        /// Any class 
        /// </typeparam>
        private static void ThrowIfFeatureNotSupported<T>(T obj) where T : class
        {
            if (obj == null)
            {
                throw new FeatureNotSupportedException("This feature is not supported. Please contact your reseller.");
            }
        }

        #endregion
    }
}