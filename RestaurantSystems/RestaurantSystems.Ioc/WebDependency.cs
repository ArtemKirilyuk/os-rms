//  *********************************************************************************************************************
//  <copyright file="WebDependency.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Ioc
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 13-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Ioc
{
    #region imports

    using Autofac;

    using Microsoft.AspNet.Identity;

    using RestaurantSystems.Core.Manager;
    using RestaurantSystems.Core.UnitOfWork;
    using RestaurantSystems.Core.User;
    using RestaurantSystems.DataAccess.Context;
    using RestaurantSystems.DataAccess.UnitOfWork;
    using RestaurantSystems.Main.Managers;
    using RestaurantSystems.Main.Stores;

    #endregion

    /// <summary>
    ///     The web dependency.
    /// </summary>
    public static class WebDependency
    {
        #region Static Fields

        /// <summary>
        ///     The container.
        /// </summary>
        private static IContainer container;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The create container.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <returns>
        /// The <see cref="IContainer"/>.
        /// </returns>
        public static IContainer CreateContainer(ContainerBuilder builder)
        {
            builder.Register(x => new RestaurantContext()).As<RestaurantContext>();

            builder.Register(c => new RestaurantUnitOfWork(c.Resolve<RestaurantContext>()))
                .As<IUnitOfWork>()
                .InstancePerDependency();

            builder.Register(c => new RestaurantUserStore(c.Resolve<IUnitOfWork>())).As<IUserStore<User>>();

            builder.Register(c => new SecurityManager(c.Resolve<IUnitOfWork>())).As<ISecurityManager>();

            builder.Register(c => new OrderManager(c.Resolve<IUnitOfWork>())).As<IOrderManager>();

            builder.Register(c => new BookingManagement(c.Resolve<IUnitOfWork>())).As<IBookingManagement>();

            builder.Register(c => new CustomerManager(c.Resolve<IUnitOfWork>())).As<ICustomerManager>();

            builder.Register(c => new ProductManager(c.Resolve<IUnitOfWork>())).As<IProductManager>();

            container = builder.Build();

            return container;
        }

        /// <summary>
        ///     The resolve.
        /// </summary>
        /// <typeparam name="T">
        ///     any interface or class
        /// </typeparam>
        /// <returns>
        ///     The <see cref="T" />.
        /// </returns>
        public static T Resolve<T>()
        {
            if (container == null)
            {
                CreateContainer(new ContainerBuilder());
            }

            T ret = default(T);

            if (container.IsRegistered(typeof(T)))
            {
                ret = container.Resolve<T>();
            }

            return ret;
        }

        #endregion
    }
}