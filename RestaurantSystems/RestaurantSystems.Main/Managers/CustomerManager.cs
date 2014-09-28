//  *********************************************************************************************************************
//  <copyright file="CustomerManager.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Main
//   Author           : Abdul Aziz
//   Created          : 10-09-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 20-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Main.Managers
{
    #region imports

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RestaurantSystems.Core.Entities;
    using RestaurantSystems.Core.Manager;
    using RestaurantSystems.Core.UnitOfWork;
    using RestaurantSystems.DataAccess.Model;

    #endregion

    /// <summary>
    ///     The customer management.
    /// </summary>
    public class CustomerManager : ICustomerManager
    {
        #region Fields

        /// <summary>
        ///     The unit of work.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerManager"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        public CustomerManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add new CustomerEntity.
        /// </summary>
        /// <param name="customerEntity">
        /// The CustomerEntity.
        /// </param>
        public void AddCustomer(CustomerEntity customerEntity)
        {
            var cust = new Customer
                           {
                               AddressLine1 = customerEntity.AddressLine1, 
                               AddressLine2 = customerEntity.AddressLine2, 
                               CustomerTypeId = 1, 
                               Disabled = false, 
                               FirstName = customerEntity.FirstName, 
                               LastName = customerEntity.LastName, 
                               MobilePhone = customerEntity.MobilePhone, 
                               PostCode = customerEntity.PostCode, 
                               TelePhone = customerEntity.TelePhone, 
                           };

            this.unitOfWork.Repository<Customer>().Add(cust);
            this.unitOfWork.Save();
        }

        /// <summary>
        /// The remove CustomerEntity.
        /// </summary>
        /// <param name="customerId">
        /// The customer identifier.
        /// </param>
        public void RemoveCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The search customer full.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<CustomerEntity> SearchCustomerFull(string query)
        {
            var searchResult =
                this.unitOfWork.Repository<Customer>()
                    .Query()
                    .Where(
                        x =>
                        x.FirstName.ToUpper().Contains(query.ToUpper())
                        || x.LastName.ToUpper().Contains(query.ToUpper()) || x.MobilePhone.Contains(query.ToUpper())
                        || x.TelePhone.Contains(query.ToUpper()))
                    .Select(
                        x =>
                        new CustomerEntity
                            {
                                Id = x.Id, 
                                FirstName = x.FirstName, 
                                LastName = x.LastName, 
                                AddressLine1 = x.AddressLine1, 
                                AddressLine2 = x.AddressLine2, 
                                City = x.PostCode, 
                                PostCode = x.PostCode, 
                                TelePhone = x.TelePhone, 
                                MobilePhone = x.MobilePhone, 
                            })
                    .Take(5);

            return searchResult.ToList();
        }

        /// <summary>
        /// The search.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{ShortCustomerEntity}"/>.
        /// </returns>
        public IEnumerable<ShortCustomerEntity> SearchCustomerShort(string query)
        {
            var searchResult =
                this.unitOfWork.Repository<Customer>()
                    .Query()
                    .Where(
                        x =>
                        x.FirstName.ToUpper().Contains(query.ToUpper())
                        || x.LastName.ToUpper().Contains(query.ToUpper()) || x.MobilePhone.Contains(query.ToUpper())
                        || x.TelePhone.Contains(query.ToUpper()))
                    .Select(
                        x =>
                        new ShortCustomerEntity
                            {
                                Id = x.Id, 
                                Fullname = x.FirstName + " " + x.LastName, 
                                PhoneNumber = x.TelePhone, 
                                MobileNumber = x.MobilePhone, 
                            })
                    .Take(5);

            return searchResult.ToList();
        }

        /// <summary>
        /// The update CustomerEntity.
        /// </summary>
        /// <param name="customerEntity">
        /// The CustomerEntity.
        /// </param>
        public void UpdateCustomer(CustomerEntity customerEntity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}