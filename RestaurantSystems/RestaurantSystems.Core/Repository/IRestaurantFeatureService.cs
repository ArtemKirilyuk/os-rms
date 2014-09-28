//  ***********************************************************************
//  <copyright file="IRestaurantFeatureService.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Core
//   Author           : Abdul Aziz
//   Created          : 22-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 22-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Core.Repository
{
    #region imports

    using System;
    using System.Collections.Generic;

    using RestaurantSystems.Core.Entities;

    #endregion

    /// <summary>
    /// The Restaurant interface.
    /// </summary>
    public interface IRestaurantFeatureService
    {
        #region Public Methods and Operators

        /// <summary>
        /// The cancel booking.
        /// </summary>
        /// <param name="bookingId">
        /// The booking id.
        /// </param>
        void CancelBooking(int bookingId);

        /// <summary>
        /// The confirm booking.
        /// </summary>
        /// <param name="bookingId">
        /// The booking id.
        /// </param>
        void ConfirmBooking(int bookingId);

        /// <summary>
        /// The create booking.
        /// </summary>
        /// <param name="from">
        /// From.
        /// </param>
        /// <param name="till">
        /// To.
        /// </param>
        /// <param name="forCustomerId">
        /// The for customer id.
        /// </param>
        /// <param name="forPeople">
        /// For people.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// Please provide either table number or room till make a booking
        /// </exception>
        /// <exception cref="System.Data.DataException">
        /// Provided room with Id( + roomId.Value + ) does not exist.
        /// or
        /// Unable till find customer with the provided Id ( + forCustomerId + )
        /// </exception>
        /// <exception cref="System.ApplicationException">
        /// Booking already exists on this time for specified table/room. Please cancel existing booking to rebook
        /// </exception>
        void CreateBooking(DateTime from, DateTime till, int forCustomerId, int forPeople);

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
        /// The <see cref="IEnumerable{BookingEntity}"/>.
        /// </returns>
        IEnumerable<BookingEntity> GetBooking(int? customerId, int? bookingId, DateTime? from, DateTime? till);

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
        void MoveBooking(int bookingId, DateTime startDate, DateTime endDate);

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
        /// The <see cref="IEnumerable{BookingEntity}"/>.
        /// </returns>
        IEnumerable<BookingEntity> Search(DateTime? from, string customer);

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
        void UpdateBooking(int bookingId, int forPeople, DateTime from, DateTime till);

        #endregion
    }
}