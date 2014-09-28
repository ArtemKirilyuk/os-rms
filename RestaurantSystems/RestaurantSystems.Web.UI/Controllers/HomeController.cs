//  *********************************************************************************************************************
//  <copyright file="HomeController.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 14-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 08-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Web.UI.Controllers
{
    #region imports

    using System.Web.Mvc;

    #endregion

    /// <summary>
    /// The home controller.
    /// </summary>
    [AllowAnonymous]
    public class HomeController : Controller
    {
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