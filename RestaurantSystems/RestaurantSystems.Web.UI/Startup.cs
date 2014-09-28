//  *********************************************************************************************************************
//  <copyright file="Startup.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 14-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 13-09-2014
//  *********************************************************************************************************************
#region imports

using Microsoft.Owin;

using RestaurantSystems.Web.UI;

#endregion

[assembly: OwinStartup(typeof(Startup))]

namespace RestaurantSystems.Web.UI
{
    #region imports

    using Owin;

    #endregion

    /// <summary>
    ///     The startup.
    /// </summary>
    public partial class Startup
    {
        #region Public Methods and Operators

        /// <summary>
        /// The configuration.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }

        #endregion
    }
}