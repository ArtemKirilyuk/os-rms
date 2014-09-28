//  ***********************************************************************
//  <copyright file="OrderManager.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Main
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 17-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Main.Managers
{
    #region imports

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using RestaurantSystems.Core.Entities;
    using RestaurantSystems.Core.Interfaces;
    using RestaurantSystems.Core.Manager;
    using RestaurantSystems.Core.UnitOfWork;
    using RestaurantSystems.DataAccess.Model;

    #endregion

    /// <summary>
    /// The order system system.
    /// </summary>
    public class OrderManager : IOrderManager
    {
        #region Fields

        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderManager"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        public OrderManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The cancel order.
        /// </summary>
        /// <param name="orderId">
        /// The order id.
        /// </param>
        public void CancelOrder(int orderId)
        {
            var order = this.unitOfWork.Repository<OrderHeader>().Query().FirstOrDefault(x => x.Id == orderId);

            if (order == null)
            {
                throw new DataException("Could not find the order with provided Id (" + orderId + ")");
            }

            order.Cancelled = true;

            this.unitOfWork.Repository<OrderHeader>().Update(order);
            this.unitOfWork.Save();
        }

        /// <summary>
        /// The get order detail.
        /// </summary>
        /// <param name="headerId">The header id.</param>
        /// <returns>
        /// The <see cref="OrderDetailEntity" />.
        /// </returns>
        public IEnumerable<OrderDetailEntity> GetOrderDetail(int headerId)
        {
            var detail =
                this.unitOfWork.Repository<OrderDetail>().Query().Where(x => x.OrderHeaderId == headerId);

            return
                detail.Select(
                    x =>
                    new OrderDetailEntity
                        {
                            Price = x.Price,
                            Product = x.Product.LongName,
                            Quantity = x.Quantity,
                            SpiceType = x.SpiceType.Description,
                            Total = x.Total
                        }).ToList();
        }

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
        public IEnumerable<OrderHeaderEntity> GetOrdersFor(int? customerId, DateTime? startDate, DateTime? endDate)
        {
            var orders =
                this.unitOfWork.Repository<OrderHeader>()
                    .Query()
                    .Where(
                        x =>
                        (!customerId.HasValue || x.CustomerId == customerId.Value)
                        && (!startDate.HasValue || x.OrderDate >= startDate.Value)
                        && (!endDate.HasValue || x.OrderDate <= endDate.Value))
                    .Select(
                        x =>
                        new OrderHeaderEntity
                            {
                                Discount = x.Discount, 
                                FullName = x.Customer.FirstName + " " + x.Customer.LastName, 
                                Id = x.Id,
                                AddressLine1 = x.Customer.AddressLine1,
                                AddressLine2 = x.Customer.AddressLine2,
                                OrderDate = x.OrderDate,
                                PostCode = x.Customer.PostCode,
                                SubTotal = x.SubTotal, 
                                Total = x.Total
                            });

            return orders;
        }

        /// <summary>
        /// The get previous orders.
        /// </summary>
        /// <param name="customerId">
        /// The customer id.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetPreviousOrders(int customerId)
        {
            var ordersCount = this.unitOfWork.Repository<OrderHeader>().Query().Count(x => x.CustomerId == customerId);

            return ordersCount;
        }

        /// <summary>
        /// The place order.
        /// </summary>
        /// <param name="customerId">The customer id.</param>
        /// <param name="products">The products.</param>
        /// <exception cref="System.ArgumentException">Please provide atleast one product to place an order.</exception>
        /// <exception cref="System.Data.DataException">Unable to find customer with provided Id ( + customerId + )
        /// or
        /// Unable to find product with provided Id ( + product.Id + )</exception>
        public void PlaceOrder(int customerId, IEnumerable<ProductLine> products)
        {
            var productArray = products as ProductLine[] ?? products.ToArray();

            if (products == null || !productArray.Any())
            {
                throw new ArgumentException("Please provide atleast one product to place an order.");
            }

            var doesCustomerExist = this.unitOfWork.Repository<Customer>().Query().Any(x => x.Id == customerId);

            if (!doesCustomerExist)
            {
                throw new DataException("Unable to find customer with provided Id (" + customerId + ")");
            }

            var orderDetails =
                productArray.Where(x => x.Id > 0)
                    .Select(
                        x =>
                        new OrderDetail
                            {
                                ProductId = x.Id,
                                Price = x.Price,
                                Quantity = x.Quantity,
                                SpiceTypeId = x.Spice,
                                Total = x.Total
                            }).ToList();


            var totalPrice = orderDetails.Sum(x => x.Total);

            var header = new OrderHeader
                             {
                                 Cancelled = false,
                                 CustomerId = customerId,
                                 Discount = 0,
                                 SubTotal = totalPrice,
                                 Total = 0,
                                 OrderDetails = orderDetails,
                                 OrderDate = DateTime.Now,
                                 OrderTypeId = 0,
                                 Notes = string.Empty
                             };

            var discountRecord = productArray.FirstOrDefault(x => x.Id == -2);

            if (discountRecord != null)
            {
                header.Discount = discountRecord.Total;
            }

            header.Total = header.SubTotal - header.Discount;

            this.unitOfWork.Repository<OrderHeader>().Add(header);
            this.unitOfWork.Save();
        }

        #endregion
    }
}