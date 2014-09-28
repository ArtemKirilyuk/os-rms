//  ***********************************************************************
//  <copyright file="ProductController.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 16-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 30-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Web.UI.Controllers
{
    #region imports

    using System;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    using RestaurantSystems.Core.Entities;
    using RestaurantSystems.Core.Interfaces;
    using RestaurantSystems.Core.Manager;

    #endregion

    /// <summary>
    /// The product controller.
    /// </summary>
    public class ProductController : BaseController
    {
        #region Fields

        /// <summary>
        /// The product management.
        /// </summary>
        private readonly IProductManager productManager;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class. 
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="securityManagemnt">
        /// The security store.
        /// </param>
        /// <param name="productManager">
        /// The product Management.
        /// </param>
        public ProductController(ISecurityManager securityManagemnt, IProductManager productManager)
            : base(securityManagemnt)
        {
            this.productManager = productManager;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add new category.
        /// </summary>
        /// <param name="category">
        /// The category.
        /// </param>
        [HttpPost]
        public void AddCategory(string category)
        {
            this.productManager.AddCategory(category);
        }

        /// <summary>
        /// The add new product.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <param name="longName">
        /// The long name.
        /// </param>
        /// <param name="shortName">
        /// The short name.
        /// </param>
        /// <param name="price">
        /// The price.
        /// </param>
        /// <param name="image">
        /// The image.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult AddProduct(
            int categoryId, 
            string longName, 
            string shortName, 
            decimal price, 
            HttpPostedFileBase image)
        {
            var imageArray = ReadToEnd(image);

            this.productManager.AddProduct(categoryId, longName, shortName, price, imageArray);

            return this.RedirectToAction("Manage");
        }

        /// <summary>
        /// The manage.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult" />.
        /// </returns>
        [HttpGet]
        public ActionResult Manage()
        {
            var products = this.productManager.GetAllProducts();

            return this.View(products);
        }

        /// <summary>
        /// Adds the edit product.
        /// </summary>
        /// <param name="productId">
        /// The product identifier.
        /// </param>
        /// <param name="categoryId">
        /// The category identifier.
        /// </param>
        /// <returns>
        /// The <see cref="PartialViewResult"/>.
        /// </returns>
        [HttpGet]
        public PartialViewResult ProductForm(int productId, int? categoryId)
        {
            ProductEntity product = this.productManager.GetProduct(productId, categoryId);

            return this.PartialView("_AddEditProduct", product);
        }

        /// <summary>
        /// The products.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        [HttpGet]
        public JsonResult Products()
        {
            var products = this.productManager.GetAllProducts();

            return this.Json(products);
        }

        /// <summary>
        /// The update product.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        /// <param name="longName">
        /// The long name.
        /// </param>
        /// <param name="shortName">
        /// The short name.
        /// </param>
        /// <param name="price">
        /// The price.
        /// </param>
        /// <param name="image">
        /// The image.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult UpdateProduct(
            int id, 
            int categoryId, 
            string longName, 
            string shortName, 
            decimal price, 
            HttpPostedFileBase image)
        {
            var imageArray = ReadToEnd(image);

            this.productManager.UpdateProduct(id, categoryId, longName, shortName, price, imageArray);

            return this.RedirectToAction("Manage");
        }

        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            this.productManager.DeleteProduct(productId);
            return this.RedirectToAction("Manage");
        }


        #endregion

        #region Methods

        /// <summary>
        /// The read to end.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>
        /// The <see cref="byte[]" />.
        /// </returns>
        private static byte[] ReadToEnd(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return null;
            }

            var stream = file.InputStream;
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                var readBuffer = new byte[4096];

                var totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            var temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                var buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }

                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

        #endregion
    }
}