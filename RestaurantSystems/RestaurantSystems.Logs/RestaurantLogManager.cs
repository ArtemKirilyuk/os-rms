//  ***********************************************************************
//  <copyright file="RestaurantLogManager.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Logs
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 03-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Logs
{
    #region imports

    using System;

    using log4net;
    using log4net.Config;

    #endregion

    /// <summary>
    /// The restaurant log manager.
    /// </summary>
    internal class RestaurantLogManager
    {
        #region Static Fields

        /// <summary>
        ///     The is logger configured
        /// </summary>
        private static bool isLoggerConfigured;

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="declaringType">
        /// Type of the declaring.
        /// </param>
        /// <returns>
        /// Logger
        /// </returns>
        public static ILog GetLogger(Type declaringType)
        {
            if (isLoggerConfigured == false)
            {
                XmlConfigurator.Configure();
            }

            isLoggerConfigured = true;
            return LogManager.GetLogger(declaringType);
        }

        #endregion
    }
}