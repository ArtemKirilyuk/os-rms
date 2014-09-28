//  ***********************************************************************
//  <copyright file="Repository.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.DataAccess
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 03-08-2014
//  ***********************************************************************
namespace RestaurantSystems.DataAccess.Repository
{
    #region imports

    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;

    using RestaurantSystems.Core.Interfaces;
    using RestaurantSystems.Core.Repository;
    using RestaurantSystems.Logs;

    #endregion

    /// <summary>
    /// The repository.
    /// </summary>
    /// <typeparam name="T">Class that inherits from IEntity
    /// </typeparam>
    public class Repository<T> : IRepository<T>
        where T : class, IEntity<int>
    {
        #region Fields

        /// <summary>
        /// The context.
        /// </summary>
        private readonly DbContext context;

        /// <summary>
        /// The db set.
        /// </summary>
        private readonly IDbSet<T> databaseSet;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class. 
        /// Initializes a new instance of the <see cref="Repository{TDatabaseObject}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public Repository(DbContext context)
        {
            RestaurantLogger<Repository<T>>.Info("Initialising repository");
            this.context = context;
            this.databaseSet = context.Set<T>();

            this.context.Database.Log = s => Debug.WriteLine(s);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class. 
        /// Initializes a new instance of the <see cref="Repository{TDatabaseObject}"/> class.
        /// NOTE THAT THIS CONSTRUCTOR IS PURELY FOR TESTING AND SHOULD NOT BE USED FOR ANYTHING ELSE!
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="databaseSet">
        /// The database set.
        /// </param>
        public Repository(DbContext context, IDbSet<T> databaseSet)
        {
            RestaurantLogger<Repository<T>>.Info("Initialising repository for unit testing");
            this.context = context;
            this.databaseSet = databaseSet;

            // NOTE THAT THIS CONSTRUCTOR IS PURELY FOR TESTING AND SHOULD NOT BE USED FOR ANYTHING ELSE!
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Add(T entity)
        {
            RestaurantLogger<Repository<T>>.Info("Attempting to add new item");
            if (entity == null)
            {
                RestaurantLogger<Repository<T>>.Error("The item attempted to add is null");
                throw new ArgumentNullException("entity");
            }

            this.databaseSet.Add(entity);
            RestaurantLogger<Repository<T>>.Info("Sucessfully added new item");
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Delete(T entity)
        {
            RestaurantLogger<Repository<T>>.Info("Attempting to delete item");

            if (entity == null)
            {
                RestaurantLogger<Repository<T>>.Error("The item attempted to delete is null");
                throw new ArgumentNullException("entity");
            }

            var entry = this.context.Entry(entity);

            if (entry != null && entry.State == EntityState.Detached)
            {
                RestaurantLogger<Repository<T>>.Info(
                    "item exists in context but in detached state, so attaching it again.");
                this.databaseSet.Attach(entity);
            }

            RestaurantLogger<Repository<T>>.Info(
                "item is not in detached state or item does not exists in context collection so removing it.");
            this.databaseSet.Remove(entity);

            RestaurantLogger<Repository<T>>.Info("Sucessfully removed item");
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        public virtual IQueryable<T> Query()
        {
            RestaurantLogger<Repository<T>>.Info("Projecting Database Entity Query to view model entity query");

            var proj = this.databaseSet.AsQueryable();

            RestaurantLogger<Repository<T>>.Info(
                "Projection successful. Returning projected query back for execution or futher querying.");
            return proj;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual void Update(T entity)
        {
            RestaurantLogger<Repository<T>>.Info("Updating an existing item in the database.");

            if (entity == null)
            {
                RestaurantLogger<Repository<T>>.Error("The item attempted to update is null");
                throw new ArgumentNullException("entity");
            }

            RestaurantLogger<Repository<T>>.Info("Getting the entry of this mapped object from context collection");
            var entry = this.context.Entry(entity);

            if (entry != null && entry.State == EntityState.Detached)
            {
                RestaurantLogger<Repository<T>>.Info(
                    "item exists in context but in detached state, so re obtain it from database.");
                var existingEntity = this.databaseSet.Find(entity.Id);

                if (existingEntity != null)
                {
                    RestaurantLogger<Repository<T>>.Info("Set the parent object's values to mapped object's values");
                    this.context.Entry(existingEntity).CurrentValues.SetValues(entity);
                }
                else
                {
                    RestaurantLogger<Repository<T>>.Info(
                        "Item not found in database. So set current state to modified to recreate it in database.");
                    entry.State = EntityState.Modified;
                }
            }
            else
            {
                RestaurantLogger<Repository<T>>.Info(
                    "Item does not exists in context at all. So attach it to context change the state to modifed to create it in database.");

                this.databaseSet.Attach(entity);
                this.context.Entry(entity).State = EntityState.Modified;
            }

            RestaurantLogger<Repository<T>>.Info("Successfully updated item in the database.");
        }

        #endregion
    }
}