//  ***********************************************************************
//  <copyright file="ICustomerManager.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Core
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 12-08-2014
//  ***********************************************************************

namespace RestaurantSystems.Core.Manager
{
    #region imports

    using System.Collections.Generic;

    using RestaurantSystems.Core.Entities;

    #endregion
    
    /// <summary>
    /// The UserManagement interface.
    /// </summary>
    public interface ICustomerManager
    {
        #region Public Methods and Operators
        
        /// <summary>
        /// The add new CustomerEntity.
        /// </summary>
        /// <param name="customerEntity">
        /// The CustomerEntity.
        /// </param>
        void AddCustomer(CustomerEntity customerEntity);
        
        /// <summary>
        /// The remove CustomerEntity.
        /// </summary>
        /// <param name="customerId">
        /// The customer identifier.
        /// </param>
        void RemoveCustomer(int customerId);
        
        /// <summary>
        /// The search.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{ShortCustomerEntity}"/>.
        /// </returns>
        IEnumerable<ShortCustomerEntity> SearchCustomerShort(string query);

        /// <summary>
        /// Search customer full
        /// </summary>
        /// <param name="query">searc strubg</param>
        /// <returns>List of customers</returns>
        IEnumerable<CustomerEntity> SearchCustomerFull(string query);
        
        /// <summary>
        /// The update CustomerEntity.
        /// </summary>
        /// <param name="customerEntity">
        /// The CustomerEntity.
        /// </param>
        void UpdateCustomer(CustomerEntity customerEntity);

        #endregion
    }
}