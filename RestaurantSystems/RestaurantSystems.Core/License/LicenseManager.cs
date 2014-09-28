//  ***********************************************************************
//  <copyright file="LicenseManager.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Core
//   Author           : Abdul Aziz
//   Created          : 22-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 23-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Core.License
{
    #region imports

    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    using RestaurantSystems.Common;

    #endregion

    /// <summary>
    /// The license manager.
    /// </summary>
    public static class LicenseManager
    {
        #region Public Methods and Operators

        /// <summary>
        /// The get current license.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetCurrentLicense()
        {
            return
                @"S2MHC2L8dfEsUt6/aPjuKyb/EUCUAFGUs6lVfTADF4SPwPYhqekTViIQOgGHPNbUVKruJqpriMKrV6bqTdRiO06ZfJInxQy3RjX8x8mi7QgFwE9iqrtditNEmXuImtaXaHV0Fk/5J0On0xHCGBanbOpmitJF9fedkZsgBNZ8OOPav1sLZVGYQeIkmmKYA1CGtd9VEt9v4gKLez6PBPAlckSAAMnyRT4cal/zRSATv3KUW2DEgnlmk0rSHPQJVF+/IGXFqYDLHRzMuR/C8i3oSA==";
        }

        /// <summary>
        /// The update license.
        /// </summary>
        public static void UpdateLicense()
        {
        }

        /// <summary>
        /// The verify license.
        /// </summary>
        /// <param name="forFeature">
        /// The for feature.
        /// </param>
        public static void VerifyLicense(string forFeature)
        {
            var license = GetCurrentLicense();

            var decrypt = DecryptLicense(license);

            var unshuffled = Unshuffle(decrypt);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The shuffle.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string DeShuffle(string str)
        {
            const int Repeater = 2;
            var iterations = Math.Ceiling((decimal)str.Length / Repeater);

            var shuffed = string.Empty;

            for (var i = 1; i <= iterations; i++)
            {
                var index = str.Length - (i * Repeater);

                if (index < 0)
                {
                    shuffed += str.Substring(0, str.Length - shuffed.Length);
                }
                else
                {
                    shuffed += str.Substring(index, Repeater);
                }
            }

            return shuffed;
        }

        /// <summary>
        /// The decrypt license.
        /// </summary>
        /// <param name="license">
        /// The license.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string DecryptLicense(string license)
        {
            const string Password = "password";
            const string Salt = "salt";

            return CipherUtility.Decrypt<RijndaelManaged>(license, Password, Salt);
        }

        /// <summary>
        /// The unshuffle.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string Unshuffle(string str)
        {
            return str;
        }

        #endregion
    }
}