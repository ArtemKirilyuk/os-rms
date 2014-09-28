//  *********************************************************************************************************************
//  <copyright file="Role.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.DataAccess
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 13-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.DataAccess.Model
{
    #region imports

    using Microsoft.AspNet.Identity.EntityFramework;

    using RestaurantSystems.Core.Interfaces;
    using RestaurantSystems.Core.User;

    #endregion

    /// <summary>
    ///     The role.
    /// </summary>
    public class Role : IdentityRole, IEntity<string>
    {
        #region Public Properties
        
        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        #endregion
    }
}