//  ***********************************************************************
//  <copyright file="RestaurantLogger.cs" company="Abdul Aziz">
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
    /// <summary>
    /// The restaurant logger.
    /// </summary>
    /// <typeparam name="T">Any class.
    /// </typeparam>
    public class RestaurantLogger<T>
        where T : class
    {
        #region Public Methods and Operators

        /// <summary>
        /// The error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Error(string message, params object[] args)
        {
            var logger = RestaurantLogManager.GetLogger(typeof(T));
            logger.Error(string.Format(message, args));
        }

        /// <summary>
        /// The fatal.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Fatal(string message, params object[] args)
        {
            var logger = RestaurantLogManager.GetLogger(typeof(T));
            logger.Fatal(string.Format(message, args));
        }

        /// <summary>
        /// The info.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Info(string message, params object[] args)
        {
            var logger = RestaurantLogManager.GetLogger(typeof(T));
            logger.Info(string.Format(message, args));
        }

        /// <summary>
        /// The warn.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Warn(string message, params object[] args)
        {
            var logger = RestaurantLogManager.GetLogger(typeof(T));
            logger.Warn(string.Format(message, args));
        }

        #endregion
    }
}