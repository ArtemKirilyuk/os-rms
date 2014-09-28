//  ***********************************************************************
//  <copyright file="IOrderManager.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Core
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 19-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Core.Manager
{
    #region imports

    using System;
    using System.Collections.Generic;

    using RestaurantSystems.Core.Entities;

    #endregion

    /// <summary>
    /// The OrderSystem interface.
    /// </summary>
    public interface IOrderManager
    {
        #region Public Methods and Operators

        /// <summary>
        /// The cancel order.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        void CancelOrder(int orderId);

        /// <summary>
        /// The get order detail.
        /// </summary>
        /// <param name="headerId">The header id.</param>
        /// <returns>
        /// The <see cref="OrderDetailEntity" />.
        /// </returns>
        IEnumerable<OrderDetailEntity> GetOrderDetail(int headerId);

        /// <summary>
        /// The get orders for.
        /// </summary>
        /// <param name="customerId">
        /// The customer id.
        /// </param>
        /// <param name="startDate">
        /// The start Date.
        /// </param>
        /// <param name="endDate">
        /// The end Date.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{OrderHeaderEntity}"/>.
        /// </returns>
        IEnumerable<OrderHeaderEntity> GetOrdersFor(int? customerId, DateTime? startDate, DateTime? endDate);

        /// <summary>
        /// The get previous orders.
        /// </summary>
        /// <param name="customerId">
        /// The customer id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int GetPreviousOrders(int customerId);

        /// <summary>
        /// The place order.
        /// </summary>
        /// <param name="customerId">
        /// The customer id.
        /// </param>
        /// <param name="products">
        /// The products.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// Please provide atleast one product to place an order.
        /// </exception>
        /// <exception cref="System.Data.DataException">
        /// Unable to find customer with provided Id ( + customerId + )
        /// or
        /// Unable to find product with provided Id ( + product.Id + )
        /// </exception>
        void PlaceOrder(int customerId, IEnumerable<ProductLine> products);

        #endregion
    }
}