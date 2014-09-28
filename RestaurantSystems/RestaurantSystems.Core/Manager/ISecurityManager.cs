//  *********************************************************************************************************************
//  <copyright file="ISecurityManager.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Core
//   Author           : Abdul Aziz
//   Created          : 13-09-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 13-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Core.Manager
{
    #region imports

    using System;

    #endregion

    /// <summary>
    ///     The SecurityManagement interface.
    /// </summary>
    public interface ISecurityManager
    {
        #region Public Methods and Operators

        /// <summary>
        /// The is User allowed to access.
        /// </summary>
        /// <param name="controllerName">
        /// The controller name.
        /// </param>
        /// <param name="actionName">
        /// The action name.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool IsUserAllowedToAccess(string controllerName, string actionName, string name);

        #endregion
    }
}