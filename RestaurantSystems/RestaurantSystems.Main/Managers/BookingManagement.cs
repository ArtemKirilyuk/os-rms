//  ***********************************************************************
//  <copyright file="BookingManagement.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Main.Booking
//   Author           : Abdul Aziz
//   Created          : 22-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 22-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Main.Managers
{
    #region imports

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using RestaurantSystems.Core.Entities;
    using RestaurantSystems.Core.Manager;
    using RestaurantSystems.Core.UnitOfWork;
    using RestaurantSystems.DataAccess.Model;

    #endregion

    /// <summary>
    /// The bookings system.
    /// </summary>
    public class BookingManagement : IBookingManagement
    {
        #region Fields

        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingManagement"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        public BookingManagement(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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
            var booking = this.unitOfWork.Repository<Booking>().Query().FirstOrDefault(x => x.Id == bookingId);

            if (booking == null)
            {
                throw new DataException("Could not find the booking with the provided Id (" + bookingId + ")");
            }

            booking.Cancelled = true;

            this.unitOfWork.Repository<Booking>().Update(booking);
            this.unitOfWork.Save();
        }

        /// <summary>
        /// The confirm booking.
        /// </summary>
        /// <param name="bookingId">
        /// The booking id.
        /// </param>
        public void ConfirmBooking(int bookingId)
        {
            var booking = this.unitOfWork.Repository<Booking>().Query().FirstOrDefault(x => x.Id == bookingId);

            if (booking == null)
            {
                throw new DataException("Could not find the booking with the provided Id (" + bookingId + ")");
            }

            booking.Confirmed = true;

            this.unitOfWork.Repository<Booking>().Update(booking);
            this.unitOfWork.Save();
        }

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
        public void CreateBooking(DateTime from, DateTime till, int forCustomerId, int forPeople)
        {
            if (from > till)
            {
                throw new ArgumentException("From date cannot be greater than till date!");
            }

            var customer = this.unitOfWork.Repository<Customer>().Query().FirstOrDefault(x => x.Id == forCustomerId);

            if (customer == null)
            {
                throw new DataException("Unable till find customer with the provided Id (" + forCustomerId + ")");
            }

            var booking = new Booking
                              {
                                  Cancelled = false, 
                                  CustomerId = forCustomerId, 
                                  From = from, 
                                  Till = till, 
                                  BookingTypeId = 1, 
                                  ForPeople = forPeople, 
                                  RequestedOn = DateTime.Now
                              };

            this.unitOfWork.Repository<Booking>().Add(booking);
            this.unitOfWork.Save();
        }

        /// <summary>
        /// The get all booking.
        /// </summary>
        /// <param name="customerId">
        /// The customer identifier.
        /// </param>
        /// <param name="bookingId">
        /// The booking Id.
        /// </param>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="till">
        /// The till.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{Booking}"/>.
        /// </returns>
        public IEnumerable<BookingEntity> GetBooking(int? customerId, int? bookingId, DateTime? from, DateTime? till)
        {
            var bookings =
                this.unitOfWork.Repository<Booking>()
                    .Query()
                    .Where(
                        x =>
                        (!customerId.HasValue || x.CustomerId == customerId) && (!from.HasValue || x.From >= from)
                        && (!till.HasValue || x.Till <= till));

            return this.SelectAsBookingEntities(bookings);
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
            var booking = this.unitOfWork.Repository<Booking>().Query().FirstOrDefault(x => x.Id == bookingId);

            if (booking == null)
            {
                throw new ArgumentException(
                    string.Format("Booking with id {0} does not exist in the database.", bookingId));
            }

            booking.From = startDate;
            booking.Till = endDate;

            this.unitOfWork.Repository<Booking>().Update(booking);
            this.unitOfWork.Save();
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
        /// The <see cref="IEnumerable{BookingEntity}"/>.
        /// </returns>
        public IEnumerable<BookingEntity> Search(DateTime? from, string customer)
        {
            customer = customer == null ? null : customer.ToUpper();

            var bookings =
                this.unitOfWork.Repository<Booking>()
                    .Query()
                    .Where(
                        x =>
                        (!from.HasValue || x.From >= from.Value)
                        && (customer == null
                            || (x.Customer.MobilePhone.Contains(customer) || x.Customer.TelePhone.Contains(customer)
                                || x.Customer.FirstName.ToUpper().Contains(customer)
                                || x.Customer.LastName.ToUpper().Contains(customer))))
                    .Take(100);

            return this.SelectAsBookingEntities(bookings);
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
            var booking = this.unitOfWork.Repository<Booking>().Query().FirstOrDefault(x => x.Id == bookingId);

            if (booking == null)
            {
                throw new ArgumentException(
                    string.Format("Booking with id {0} does not exist in the database.", bookingId));
            }

            booking.ForPeople = forPeople;
            booking.From = from;
            booking.Till = till;

            this.unitOfWork.Repository<Booking>().Update(booking);
            this.unitOfWork.Save();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The select as booking entities.
        /// </summary>
        /// <param name="queryable">
        /// The queryable.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{BookingEntity}"/>.
        /// </returns>
        private IEnumerable<BookingEntity> SelectAsBookingEntities(IQueryable<Booking> queryable)
        {
            var result =
                queryable.Select(
                    x =>
                    new BookingEntity
                        {
                            From = x.From, 
                            Till = x.Till, 
                            Id = x.Id, 
                            Mobilephone = x.Customer.MobilePhone, 
                            Telephone = x.Customer.TelePhone, 
                            CustomerName = x.Customer.FirstName + " " + x.Customer.LastName, 
                            AddressLine1 = x.Customer.AddressLine1, 
                            AddressLine2 = x.Customer.AddressLine2, 
                            Postcode = x.Customer.PostCode, 
                            TableFor = x.ForPeople, 
                            CustomerId = x.CustomerId, 
                            Cancelled = x.Cancelled
                        }).ToList();

            return result;
        }

        #endregion
    }
}