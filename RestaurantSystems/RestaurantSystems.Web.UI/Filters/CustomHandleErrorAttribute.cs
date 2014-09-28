//  *********************************************************************************************************************
//  <copyright file="CustomHandleErrorAttribute.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 07-09-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 07-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Web.UI.Filters
{
    #region imports

    using System.Web.Mvc;

    using RestaurantSystems.Web.UI.Models;

    #endregion

    /// <summary>
    /// The handle error.
    /// </summary>
    public class CustomHandleErrorAttribute : FilterAttribute, IExceptionFilter
    {
        #region Public Methods and Operators

        /// <summary>
        /// Called when an exception occurs.
        /// </summary>
        /// <param name="filterContext">
        /// The filter context.
        /// </param>
        public void OnException(ExceptionContext filterContext)
        {
            var errorModel = new ErrorViewModel();
            if (filterContext.RequestContext.HttpContext.Request.Url != null)
            {
                errorModel.RequestUrl = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri;
            }

            if (filterContext.Exception.GetType().Assembly.GetName().Name == "RestaurantSystems.Core.Exceptions")
            {
                errorModel.Code = 1;
                errorModel.Description = filterContext.Exception.Message;
            }
            else
            {
                errorModel.Code = 500;
                errorModel.Description = "Apologies, unknown error has occurred. Please try again later. "
                                         + "If this error persists please contact Support.";
            }

            filterContext.ExceptionHandled = true;

            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                var jsonResult = new JsonResult
                                     {
                                         Data = errorModel, 
                                         JsonRequestBehavior = JsonRequestBehavior.AllowGet
                                     };

                filterContext.Result = jsonResult;
            }
            else
            {
                filterContext.Result = new RedirectResult(filterContext.RequestContext.HttpContext.Request.UrlReferrer.AbsoluteUri);

                filterContext.Controller.ViewBag.Error = errorModel;
            }
        }

        #endregion
    }
}