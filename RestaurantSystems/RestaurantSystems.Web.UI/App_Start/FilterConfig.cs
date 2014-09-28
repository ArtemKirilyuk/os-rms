//  *********************************************************************************************************************
//  <copyright file="FilterConfig.cs" company="Abdul Aziz">
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
namespace RestaurantSystems.Web.UI
{
    #region imports

    using System.Web.Mvc;

    using RestaurantSystems.Web.UI.Filters;

    #endregion

    /// <summary>
    /// The filter config.
    /// </summary>
    public class FilterConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// The register global filters.
        /// </summary>
        /// <param name="filters">
        /// The filters.
        /// </param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute());
            filters.Add(new ClaimsAuthorizeAttribute());
        }

        #endregion
    }
}