//  ***********************************************************************
//  <copyright file="ShortCustomerEntity.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Core.Entities
//   Author           : Abdul Aziz
//   Created          : 12-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 17-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Core.Entities
{
    /// <summary>
    /// The short customer entity.
    /// </summary>
    public class ShortCustomerEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the number of previous orders.
        /// </summary>
        public int PreviousOrders { get; set; }

        /// <summary>
        /// Gets or sets the fullname.
        /// </summary>
        public string Fullname { get; set; }

        #endregion
    }
}