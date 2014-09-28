//  ***********************************************************************
//  <copyright file="OrderController.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 14-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 19-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Web.UI.Controllers
{
    #region imports

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using RestaurantSystems.Core.Entities;
    using RestaurantSystems.Core.Interfaces;
    using RestaurantSystems.Core.Manager;

    #endregion

    /// <summary>
    /// The order controller.
    /// </summary>
    public class OrderController : BaseController
    {
        #region Constants

        /// <summary>
        /// The order details.
        /// </summary>
        private const string OrderDetails = "ORDER_DETAILS";

        #endregion

        #region Fields

        /// <summary>
        /// The product management.
        /// </summary>
        private readonly IProductManager productManager;

        /// <summary>
        /// The order management.
        /// </summary>
        private readonly IOrderManager orderManager;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class. 
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="securityManagemnt">
        /// The security store.
        /// </param>
        /// <param name="productManager">
        /// The product Management.
        /// </param>
        /// <param name="orderManager">
        /// The order Management.
        /// </param>
        public OrderController(
            ISecurityManager securityManagemnt, 
            IProductManager productManager, 
            IOrderManager orderManager)
            : base(securityManagemnt)
        {
            this.productManager = productManager;
            this.orderManager = orderManager;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add new product.
        /// </summary>
        /// <param name="productId">
        /// The product identifier.
        /// </param>
        /// <param name="decrement">
        /// The decrement.
        /// </param>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        [HttpPost]
        public PartialViewResult AddNewProduct(int productId, bool? decrement)
        {
            var product = this.productManager.GetProduct(productId);

            List<ProductLine> orderDetails;

            if (this.TempData.ContainsKey(OrderDetails))
            {
                orderDetails = (List<ProductLine>)this.TempData[OrderDetails];

                var existingProduct = orderDetails.FirstOrDefault(x => x.Id == productId);

                if (existingProduct != null)
                {
                    if (decrement != null && decrement.Value)
                    {
                        existingProduct.Quantity -= 1;

                        if (existingProduct.Quantity <= 0)
                        {
                            orderDetails.Remove(existingProduct);
                        }
                    }
                    else
                    {
                        existingProduct.Quantity += 1;
                    }

                    existingProduct.Total = Math.Round(existingProduct.Price * existingProduct.Quantity, 2);
                }
                else
                {
                    existingProduct = this.GetNewProductLine(product);
                    orderDetails.Add(existingProduct);
                }

                this.TempData.Remove(OrderDetails);
                this.TempData.Add(OrderDetails, orderDetails);
            }
            else
            {
                orderDetails = new List<ProductLine> { this.GetNewProductLine(product) };
                this.TempData.Add(OrderDetails, orderDetails);
            }

            this.AdjustDiscount();

            return this.PartialView("_NewOrderDetails", orderDetails);
        }

        /// <summary>
        /// Applies the discount.
        /// </summary>
        /// <param name="discountRate">
        /// The discount rate.
        /// </param>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        [HttpPost]
        public PartialViewResult ApplyDiscount(decimal discountRate)
        {
            if (!this.TempData.ContainsKey(OrderDetails))
            {
                return this.PartialView("_NewOrderDetails", null);
            }

            var orderDetails = (List<ProductLine>)this.TempData[OrderDetails];

            var existingDiscount = orderDetails.FirstOrDefault(x => x.Id == -2);

            var totalAmount = orderDetails.Where(x => x.Id > 0).Sum(x => x.Total);

            if (existingDiscount != null)
            {
                existingDiscount.Price = discountRate;
                existingDiscount.Name = "Discount @ " + discountRate + "%";
                existingDiscount.Total = Math.Round(totalAmount * (discountRate / 100), 2);
            }
            else
            {
                var product = new ProductLine
                                  {
                                      Id = -2, 
                                      Name = "Discount @ " + discountRate + "%", 
                                      Price = discountRate, 
                                      Total = Math.Round(totalAmount * (discountRate / 100), 2)
                                  };

                orderDetails.Add(product);
            }

            this.TempData.Remove(OrderDetails);
            this.TempData.Add(OrderDetails, orderDetails);

            this.AddOrAdjustTotal();

            return this.PartialView("_NewOrderDetails", orderDetails);
        }

        /// <summary>
        /// The change spcice.
        /// </summary>
        /// <param name="productId">
        /// The product id.
        /// </param>
        /// <param name="spice">
        /// The spice.
        /// </param>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        public PartialViewResult ChangeSpcice(int productId, int spice)
        {
            if (!this.TempData.ContainsKey(OrderDetails))
            {
                return this.PartialView("_NewOrderDetails", null);
            }

            var orderDetails = (List<ProductLine>)this.TempData[OrderDetails];

            var product = orderDetails.FirstOrDefault(x => x.Id == productId);

            if (product != null)
            {
                product.Spice = spice;
            }

            this.TempData.Remove(OrderDetails);
            this.TempData.Add(OrderDetails, orderDetails);

            return this.PartialView("_NewOrderDetails", orderDetails);
        }

        /// <summary>
        /// The search.
        /// </summary>
        /// <param name="customerId">
        /// The customer Id.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpGet]
        public JsonResult GetPreviousOrdersCount(int customerId)
        {
            var count = this.orderManager.GetPreviousOrders(customerId);
            return this.Json(count, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// The new.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult NewOrder()
        {
            var products = this.productManager.GetAllProducts();

            return this.View("NewOrder", products);
        }

        /// <summary>
        /// The order detail.
        /// </summary>
        /// <param name="headerId">
        /// The header id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public PartialViewResult OrderDetail(int headerId)
        {
            var orderDetail = this.orderManager.GetOrderDetail(headerId);
            return this.PartialView("_OrderDetail", orderDetail);
        }

        /// <summary>
        /// The index.
        /// </summary>
        /// <param name="customerId">
        /// The customer Id.
        /// </param>
        /// <param name="placedOn">
        /// The placed on.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public PartialViewResult OrderHeader(int? customerId, DateTime? placedOn)
        {
            var orders = this.orderManager.GetOrdersFor(customerId, placedOn, null);
            return this.PartialView("_OrderHeaders", orders);
        }

        /// <summary>
        /// Places the order.
        /// </summary>
        /// <param name="customerId">
        /// The customer identifier.
        /// </param>
        [HttpPost]
        public void PlaceOrder(int customerId)
        {
            if (!this.TempData.ContainsKey(OrderDetails))
            {
                return;
            }

            var orderDetails = (List<ProductLine>)this.TempData[OrderDetails];
            this.orderManager.PlaceOrder(customerId, orderDetails);
            this.TempData.Remove(OrderDetails);
        }

        /// <summary>
        /// The search order.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>
        /// The <see cref="ViewResult" />.
        /// </returns>
        [HttpGet]
        public ViewResult SearchOrder(int? customerId)
        {
            if (customerId.HasValue)
            {
                var headers = this.orderManager.GetOrdersFor(customerId, null, null);
                return this.View(headers);
            }

            return this.View();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The add or adjust total.
        /// </summary>
        private void AddOrAdjustTotal()
        {
            var orderDetails = (List<ProductLine>)this.TempData[OrderDetails];

            // -1 = TOTAL
            // -2 = DISCOUNT
            var existingTotal = orderDetails.FirstOrDefault(x => x.Id == -1);

            var totalPrice = orderDetails.Where(x => x.Id > 0).Sum(x => x.Total);

            var totalQuantity = orderDetails.Where(x => x.Id > 0).Sum(x => x.Quantity);

            var discount = orderDetails.FirstOrDefault(x => x.Id == -2);

            if (discount != null)
            {
                totalPrice = totalPrice - discount.Total;
            }

            if (existingTotal != null)
            {
                existingTotal.Quantity = totalQuantity;
                existingTotal.Total = totalPrice;
            }
            else
            {
                var total = new ProductLine
                                {
                                    Id = -1, 
                                    Price = 0, 
                                    Name = "Total", 
                                    Quantity = totalQuantity, 
                                    Total = totalPrice
                                };
                orderDetails.Add(total);
            }

            this.TempData.Remove(OrderDetails);
            this.TempData.Add(OrderDetails, orderDetails);
        }

        /// <summary>
        /// Adjusts the discount.
        /// </summary>
        private void AdjustDiscount()
        {
            var orderDetails = (List<ProductLine>)this.TempData[OrderDetails];

            var existingDiscount = orderDetails.FirstOrDefault(x => x.Id == -2);

            var totalAmount = orderDetails.Where(x => x.Id > 0).Sum(x => x.Total);

            if (existingDiscount != null)
            {
                existingDiscount.Name = "Discount @ " + existingDiscount.Price + "%";
                existingDiscount.Total = Math.Round(totalAmount * (existingDiscount.Price / 100), 2);
            }

            this.AddOrAdjustTotal();
        }

        /// <summary>
        /// The get new product view model.
        /// </summary>
        /// <param name="product">
        /// The product.
        /// </param>
        /// <returns>
        /// The <see cref="ProductLine"/>.
        /// </returns>
        private ProductLine GetNewProductLine(ProductEntity product)
        {
            return new ProductLine
                       {
                           Id = product.Id, 
                           Price = product.Price, 
                           Name = product.LongName, 
                           Quantity = 1, 
                           Spice = 0, 
                           Total = product.Price
                       };
        }

        #endregion
    }
}