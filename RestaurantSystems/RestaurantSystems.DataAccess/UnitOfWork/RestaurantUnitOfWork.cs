//  *********************************************************************************************************************
//  <copyright file="RestaurantUnitOfWork.cs" company="Abdul Aziz">
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
namespace RestaurantSystems.DataAccess.UnitOfWork
{
    #region imports

    using System;
    using System.Collections;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using RestaurantSystems.Core.Repository;
    using RestaurantSystems.Core.UnitOfWork;
    using RestaurantSystems.DataAccess.Context;
    using RestaurantSystems.DataAccess.Repository;

    #endregion

    /// <summary>
    ///     Restaurant system unit of work
    /// </summary>
    public class RestaurantUnitOfWork : IUnitOfWork
    {
        #region Fields

        /// <summary>
        ///     The context.
        /// </summary>
        public readonly RestaurantContext RestaurantContext;

        /// <summary>
        ///     The _disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        ///     The _repositories.
        /// </summary>
        private Hashtable repositories;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantUnitOfWork"/> class.
        /// </summary>
        /// <param name="restaurantContext">
        /// The restaurant context.
        /// </param>
        public RestaurantUnitOfWork(RestaurantContext restaurantContext)
        {
            this.RestaurantContext = restaurantContext;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <returns>
        /// The <see cref="DbContext"/>.
        /// </returns>
        public DbContext Context()
        {
            return this.RestaurantContext;
        }

        /// <summary>
        ///     The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.RestaurantContext.Dispose();
                }
            }

            this.disposed = true;
        }

        /// <summary>
        ///     The repository.
        /// </summary>
        /// <typeparam name="T">
        ///     any calss
        /// </typeparam>
        /// <returns>
        ///     The <see cref="IRepository{T}" />.
        /// </returns>
        public IRepository<T> Repository<T>() where T : class
        {
            if (this.repositories == null)
            {
                this.repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if (!this.repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance = Activator.CreateInstance(
                    repositoryType.MakeGenericType(typeof(T)), 
                    this.RestaurantContext);

                this.repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)this.repositories[type];
        }

        /// <summary>
        ///     The save.
        /// </summary>
        public void Save()
        {
            try
            {
                this.RestaurantContext.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}