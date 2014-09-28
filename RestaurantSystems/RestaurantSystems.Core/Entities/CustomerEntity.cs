//  ***********************************************************************
//  <copyright file="CustomerEntity.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Core.Entities
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 03-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Core.Entities
{
    /// <summary>
    /// CustomerEntity entity
    /// </summary>
    public class CustomerEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the person type.
        /// </summary>
        public int CustmerTypeId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Gets or sets the address line 1.
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line 2.
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the post code.
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone.
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Gets or sets the tele phone.
        /// </summary>
        public string TelePhone { get; set; }

        #endregion
    }
}