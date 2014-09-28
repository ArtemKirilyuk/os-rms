//  ***********************************************************************
//  <copyright file="FeatureNotSupportedException.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Core.Exceptions
//   Author           : Abdul Aziz
//   Created          : 22-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 22-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Core.Exceptions
{
    #region imports

    using System;
    using System.Runtime.Serialization;

    #endregion

    /// <summary>
    /// The feature not supported exception.
    /// </summary>
    [Serializable]
    public class FeatureNotSupportedException : Exception
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureNotSupportedException"/> class.
        /// </summary>
        public FeatureNotSupportedException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureNotSupportedException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public FeatureNotSupportedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureNotSupportedException"/> class.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public FeatureNotSupportedException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureNotSupportedException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        public FeatureNotSupportedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureNotSupportedException"/> class.
        /// </summary>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="innerException">
        /// The inner exception.
        /// </param>
        /// <param name="args">
        /// The args.
        /// </param>
        public FeatureNotSupportedException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeatureNotSupportedException"/> class.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        protected FeatureNotSupportedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }
}