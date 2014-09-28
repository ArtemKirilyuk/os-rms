//  *********************************************************************************************************************
//  <copyright file="CustomerController.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 14-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 16-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Web.UI.Controllers
{
    #region imports

    using System.Linq;
    using System.Web.Mvc;

    using RestaurantSystems.Core.Entities;
    using RestaurantSystems.Core.Manager;

    #endregion

    /// <summary>
    ///     The customer controller.
    /// </summary>
    public class CustomerController : BaseController
    {
        #region Fields

        /// <summary>
        ///     The customer management.
        /// </summary>
        private readonly ICustomerManager customerManager;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        ///     Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="securityManagemnt">
        /// The security store.
        /// </param>
        /// <param name="customerManager">
        /// The customer Management.
        /// </param>
        public CustomerController(ISecurityManager securityManagemnt, ICustomerManager customerManager)
            : base(securityManagemnt)
        {
            this.customerManager = customerManager;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Adds the customer.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        [HttpPost]
        public void AddCustomer(CustomerEntity customer)
        {
            this.customerManager.AddCustomer(customer);
        }

        /// <summary>
        /// The add customer.
        /// </summary>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        [HttpGet]
        public PartialViewResult AddCustomer()
        {
            return this.PartialView("_NewCustomerFull");
        }

        /// <summary>
        ///     The manage.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        [HttpGet]
        public ActionResult Manage()
        {
            return this.View();
        }

        /// <summary>
        /// The search.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpGet]
        public JsonResult Search(string query)
        {
            var list = this.customerManager.SearchCustomerShort(query);

            return this.Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The search customer.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        [HttpGet]
        public PartialViewResult SearchCustomer(string query)
        {
            var list = this.customerManager.SearchCustomerFull(query);

            return this.PartialView("_CustomerList", list.ToList());
        }

        #endregion
    }
}