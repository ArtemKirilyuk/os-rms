//  *********************************************************************************************************************
//  <copyright file="DependencyConfig.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 14-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 08-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Web.UI
{
    #region imports

    using System.Reflection;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using RestaurantSystems.Ioc;

    #endregion

    /// <summary>
    /// The dependency config.
    /// </summary>
    public class DependencyConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// The register types.
        /// </summary>
        public static void RegisterTypes()
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();
            builder.RegisterModule<AutofacWebTypesModule>();

            var container = WebDependency.CreateContainer(builder);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        #endregion
    }
}