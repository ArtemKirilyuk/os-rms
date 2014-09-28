//  ***********************************************************************
//  <copyright file="BookingController.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 14-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 27-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Web.UI.Controllers
{
    #region imports

    using System;
    using System.Linq;
    using System.Security.Claims;
    using System.Web.Mvc;

    using RestaurantSystems.Core.Interfaces;
    using RestaurantSystems.Core.Manager;
    using RestaurantSystems.Web.UI.Filters;

    #endregion

    /// <summary>
    /// The booking controller.
    /// </summary>
    public class BookingController : BaseController
    {
        #region Fields

        /// <summary>
        /// The booking management.
        /// </summary>
        private readonly IBookingManagement bookingManagement;

        /// <summary>
        /// The customer management.
        /// </summary>
        private readonly ICustomerManager customerManager;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingController"/> class. 
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="securityManagemnt">
        /// The security store.
        /// </param>
        /// <param name="bookingManagement">
        /// The booking Management.
        /// </param>
        /// <param name="customerManager">
        /// The customer Management.
        /// </param>
        public BookingController(
            ISecurityManager securityManagemnt, 
            IBookingManagement bookingManagement, 
            ICustomerManager customerManager)
            : base(securityManagemnt)
        {
            this.bookingManagement = bookingManagement;
            this.customerManager = customerManager;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The cancel booking.
        /// </summary>
        /// <param name="bookingId">
        /// The booking id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ClaimsAuthorize("Cancel", "Booking")]
        public ActionResult CancelBooking(int bookingId)
        {
            this.bookingManagement.CancelBooking(bookingId);
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// The confirm booking.
        /// </summary>
        /// <param name="bookingId">
        /// The booking id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        [ClaimsAuthorize("Confirm", "Booking")]
        public ActionResult ConfirmBooking(int bookingId)
        {
            this.bookingManagement.ConfirmBooking(bookingId);
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// The view booking.
        /// </summary>
        /// <param name="bookingId">
        /// The booking id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        [ClaimsAuthorize("Edit", "Booking")]
        public PartialViewResult EditBooking(int bookingId)
        {
            var booking = this.bookingManagement.GetBooking(null, bookingId, null, null).FirstOrDefault();

            return this.PartialView("_EditBooking", booking);
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// News the booking.
        /// </summary>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        [HttpGet]
        [ClaimsAuthorize("New", "Booking")]
        public PartialViewResult NewBooking()
        {
            return this.PartialView("_NewBooking");
        }

        /// <summary>
        /// The save booking.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="till">
        /// The till.
        /// </param>
        /// <param name="customerId">
        /// The customer id.
        /// </param>
        /// <param name="tableFor">
        /// The table for.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult SaveBooking(DateTime from, DateTime till, int customerId, int tableFor)
        {
            this.bookingManagement.CreateBooking(from, till, customerId, 2);

            return this.RedirectToAction("Index");
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
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        [HttpPost]
        public PartialViewResult Search(DateTime? from, string customer)
            {
            var bookings = this.bookingManagement.Search(from, customer);

            return this.PartialView("_BookingList", bookings);
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
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult UpdateBooking(int bookingId, int forPeople, DateTime from, DateTime till)
        {
            this.bookingManagement.UpdateBooking(bookingId, forPeople, from, till);

            return this.RedirectToAction("Index");
        }

        #endregion
    }
}