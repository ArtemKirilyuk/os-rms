//  ***********************************************************************
//  <copyright file="Program.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.DummyTest
//   Author           : Abdul Aziz
//   Created          : 23-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 23-08-2014
//  ***********************************************************************
namespace RestaurantSystems.DummyTest
{
    using RestaurantSystems.Core.License;

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        #region Methods

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        private static void Main(string[] args)
        {
            LicenseManager.VerifyLicense(string.Empty);
        }

        #endregion
    }
}