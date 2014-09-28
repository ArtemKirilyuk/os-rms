//  ***********************************************************************
//  <copyright file="IRepository.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Core
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 03-08-2014
//  ***********************************************************************

namespace RestaurantSystems.Core.Repository
{
    #region imports

    using System.Linq;

    #endregion

    public interface IRepository<T>
        where T : class
    {
        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Add(T entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Delete(T entity);

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<T> Query();

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Update(T entity);

        #endregion
    }
}