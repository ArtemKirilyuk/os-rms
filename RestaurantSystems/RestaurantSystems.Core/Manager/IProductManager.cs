//  ***********************************************************************
//  <copyright file="IProductManager.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Core
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 30-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Core.Manager
{
    #region imports

    using System.Collections.Generic;

    using RestaurantSystems.Core.Entities;

    #endregion

    /// <summary>
    /// The ProductManagement interface.
    /// </summary>
    public interface IProductManager
    {
        #region Public Methods and Operators

        /// <summary>
        /// The add category.
        /// </summary>
        /// <param name="category">
        /// The category.
        /// </param>
        void AddCategory(string category);

        /// <summary>
        /// The add product.
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
        /// <param name="imageArray">
        /// The image array.
        /// </param>
        /// <exception cref="System.Exception">
        /// </exception>
        void AddProduct(int categoryId, string longName, string shortName, decimal price, byte[] imageArray);

        /// <summary>
        /// The remove category.
        /// </summary>
        /// <param name="category">
        /// The category.
        /// </param>
        void DeleteCategory(int category);

        /// <summary>
        /// The remove category image.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        void DeleteCategoryImage(int categoryId);

        /// <summary>
        /// The delete product.
        /// </summary>
        /// <param name="productId">
        /// The product id.
        /// </param>
        void DeleteProduct(int productId);

        /// <summary>
        /// The remove product image.
        /// </summary>
        /// <param name="productId">
        /// The product id.
        /// </param>
        void DeleteProductImage(int productId);

        /// <summary>
        /// The get all products.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{ProductEntity}"/>.
        /// </returns>
        IEnumerable<ProductEntity> GetAllProducts();

        /// <summary>
        /// The get product.
        /// </summary>
        /// <param name="productId">
        /// The product id.
        /// </param>
        /// <param name="categoryId">
        /// The category identifier.
        /// </param>
        /// <returns>
        /// The <see cref="ProductEntity"/>.
        /// </returns>
        ProductEntity GetProduct(int productId, int? categoryId = null);

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
        /// <param name="imageArray">
        /// The image array.
        /// </param>
        void UpdateProduct(int id, int categoryId, string longName, string shortName, decimal price, byte[] imageArray);

        #endregion
    }
}