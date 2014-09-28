//  *********************************************************************************************************************
//  <copyright file="IUnitOfWork.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Core
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 13-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Core.UnitOfWork
{
    #region imports

    using System.Data.Entity;

    using RestaurantSystems.Core.Repository;

    #endregion

    /// <summary>
    ///     The i unit of work.
    /// </summary>
    public interface IUnitOfWork
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <returns>
        /// The <see cref="DbContext"/>.
        /// </returns>
        DbContext Context();

        /// <summary>
        ///     The repository.
        /// </summary>
        /// <typeparam name="T">
        ///     any calss
        /// </typeparam>
        /// <returns>
        ///     The <see cref="IRepository{T}" />.
        /// </returns>
        IRepository<T> Repository<T>() where T : class;

        /// <summary>
        ///     The save.
        /// </summary>
        void Save();

        #endregion
    }
}