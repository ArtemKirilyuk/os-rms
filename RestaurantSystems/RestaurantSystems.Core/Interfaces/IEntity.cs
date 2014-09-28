//  *********************************************************************************************************************
//  <copyright file="IEntity.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Core
//   Author           : Abdul Aziz
//   Created          : 22-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 13-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Core.Interfaces
{
    /// <summary>
    /// The Entity interface.
    /// </summary>
    /// <typeparam name="T"> any structure
    /// </typeparam>
    public interface IEntity<T>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        T Id { get; set; }

        #endregion
    }
}