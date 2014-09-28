//  ***********************************************************************
//  <copyright file="ProductManager.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Main
//   Author           : Abdul Aziz
//   Created          : 16-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 30-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Main.Managers
{
    #region imports

    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RestaurantSystems.Core.Entities;
    using RestaurantSystems.Core.Interfaces;
    using RestaurantSystems.Core.Manager;
    using RestaurantSystems.Core.Repository;
    using RestaurantSystems.Core.UnitOfWork;
    using RestaurantSystems.DataAccess.Model;

    #endregion

    /// <summary>
    /// The product management.
    /// </summary>
    public class ProductManager : IProductManager
    {
        #region Fields

        /// <summary>
        /// The unit of work.
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// The product repository.
        /// </summary>
        private readonly IRepository<Product> productRepository;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductManager"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        public ProductManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = this.unitOfWork.Repository<Product>();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add category.
        /// </summary>
        /// <param name="category">
        /// The category.
        /// </param>
        public void AddCategory(string category)
        {
            var correctedCategory = category.Trim();

            var existingCategory =
                this.unitOfWork.Repository<ProductCategory>()
                    .Query()
                    .Any(x => x.Description.ToUpper() == correctedCategory.ToUpper());

            if (existingCategory)
            {
                throw new Exception(
                    string.Format("Category, {0} already exists. Please use another name.", correctedCategory));
            }

            var prodCat = new ProductCategory { Description = correctedCategory };

            this.unitOfWork.Repository<ProductCategory>().Add(prodCat);
            this.unitOfWork.Save();
        }

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
        public void AddProduct(int categoryId, string longName, string shortName, decimal price, byte[] imageArray)
        {
            var fixedLongName = longName.Trim();
            var fixedShortName = shortName.Trim();

            var existingProduct =
                this.productRepository.Query()
                    .Any(
                        x =>
                        x.LongName.ToUpper() == fixedLongName.ToLower()
                        && x.ShortName.ToUpper() == fixedShortName.ToLower() && x.ProductCategoryId == categoryId);

            if (existingProduct)
            {
                var msg =
                    string.Format(
                        "Product {0}({1}) already exists. Please use another name or modify existing product.", 
                        fixedLongName, 
                        fixedShortName);

                throw new Exception(msg);
            }

            var prod = new Product
                           {
                               Image = imageArray, 
                               Id = 0, 
                               LongName = fixedLongName, 
                               ShortName = fixedShortName, 
                               Price = price, 
                               ProductCategoryId = categoryId
                           };

            this.unitOfWork.Repository<Product>().Add(prod);

            this.unitOfWork.Save();
        }

        /// <summary>
        /// The remove category.
        /// </summary>
        /// <param name="categoryId">
        /// The category identifier.
        /// </param>
        public void DeleteCategory(int categoryId)
        {
            var rep = this.unitOfWork.Repository<ProductCategory>();

            var cat = rep.Query().FirstOrDefault(x => x.Id == categoryId);

            if (cat == null)
            {
                throw new ArgumentException("Product category could not be found.", "categoryId");
            }

            cat.Deleted = true;
            rep.Update(cat);
            this.unitOfWork.Save();
        }

        /// <summary>
        /// The remove category image.
        /// </summary>
        /// <param name="categoryId">
        /// The category id.
        /// </param>
        public void DeleteCategoryImage(int categoryId)
        {
            var rep = this.unitOfWork.Repository<ProductCategory>();

            var cat = rep.Query().FirstOrDefault(x => x.Id == categoryId);

            if (cat == null)
            {
                throw new ArgumentException("Product category could not be found.", "categoryId");
            }

            if (cat.Image == null)
            {
                return;
            }

            cat.Image = null;
            rep.Update(cat);
            this.unitOfWork.Save();
        }

        /// <summary>
        /// The delete product.
        /// </summary>
        /// <param name="productId">
        /// The product id.
        /// </param>
        public void DeleteProduct(int productId)
        {
            var prod = this.GetProductInternal(productId);

            if (prod == null)
            {
                throw new ArgumentException("Product could not be found.", "productId");
            }

            prod.Deleted = true;
            this.productRepository.Update(prod);
            this.unitOfWork.Save();
        }

        /// <summary>
        /// The remove product image.
        /// </summary>
        /// <param name="productId">
        /// The product id.
        /// </param>
        public void DeleteProductImage(int productId)
        {
            var prod = this.GetProductInternal(productId);

            if (prod == null)
            {
                throw new ArgumentException("Product could not be found.", "productId");
            }

            prod.Image = null;

            this.productRepository.Update(prod);
            this.unitOfWork.Save();
        }

        /// <summary>
        /// The get all products.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{ProductEntity}"/>.
        /// </returns>
        public IEnumerable<ProductEntity> GetAllProducts()
        {
            var product =
                this.productRepository.Query()
                    .Select(
                        x =>
                        new ProductEntity
                            {
                                Id = x.Id, 
                                Category = x.ProductCategory.Description, 
                                CategoryId = x.ProductCategoryId, 
                                Price = x.Price, 
                                LongName = x.LongName, 
                                ShortName = x.ShortName, 
                                Deleted = x.Deleted, 
                                Image = x.Image
                            });

            return product.ToList();
        }

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
        public ProductEntity GetProduct(int productId, int? categoryId = null)
        {
            if (productId <= 0)
            {
                if (categoryId == null)
                {
                    throw new ArgumentNullException("categoryId");
                }

                var category =
                    this.unitOfWork.Repository<ProductCategory>().Query().FirstOrDefault(x => x.Id == categoryId.Value);

                if (category == null)
                {
                    throw new ArgumentNullException("categoryId");
                }

                var prod = new ProductEntity { Category = category.Description, CategoryId = category.Id, Id = -1 };
                return prod;
            }

            var product =
                this.productRepository.Query()
                    .Where(x => x.Id == productId)
                    .Select(
                        x =>
                        new ProductEntity
                            {
                                Id = x.Id, 
                                Category = x.ProductCategory.Description, 
                                CategoryId = x.ProductCategoryId, 
                                Price = x.Price, 
                                LongName = x.LongName, 
                                ShortName = x.ShortName, 
                                Image = x.Image, 
                                Deleted = x.Deleted
                            });

            return product.FirstOrDefault();
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
        /// <param name="imageArray">
        /// The image array.
        /// </param>
        public void UpdateProduct(
            int id, 
            int categoryId, 
            string longName, 
            string shortName, 
            decimal price, 
            byte[] imageArray)
        {
            var fixedLongName = longName.Trim();
            var fixedShortName = shortName.Trim();

            var prod = this.GetProductInternal(id);
            prod.LongName = fixedLongName;
            prod.ShortName = fixedShortName;
            prod.Price = price;
            prod.Image = imageArray ?? prod.Image;

            this.productRepository.Update(prod);

            this.unitOfWork.Save();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get product.
        /// </summary>
        /// <param name="productId">
        /// The product id.
        /// </param>
        /// <returns>
        /// The <see cref="Product"/>.
        /// </returns>
        private Product GetProductInternal(int productId)
        {
            return this.productRepository.Query().FirstOrDefault(x => x.Id == productId);
        }

        #endregion
    }
}