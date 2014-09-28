//  ***********************************************************************
//  <copyright file="NotificationController.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 16-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 16-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Web.UI.Controllers
{
    #region imports

    using System.Web.Mvc;

    using RestaurantSystems.Core.Interfaces;
    using RestaurantSystems.Core.Manager;

    #endregion

    /// <summary>
    /// The notification controller.
    /// </summary>
    public class NotificationController : BaseController
    {
        // GET: Notification
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationController"/> class. 
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="securityManagemnt">
        /// The security store.
        /// </param>
        public NotificationController(ISecurityManager securityManagemnt)
            : base(securityManagemnt)
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.View();
        }

        #endregion
    }
}