//  ***********************************************************************
//  <copyright file="Customer.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.DataAccess
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 16-08-2014
//  ***********************************************************************
namespace RestaurantSystems.DataAccess.Model
{
    #region imports

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using RestaurantSystems.Core.Interfaces;

    #endregion

    /// <summary>
    /// Customer entity
    /// </summary>
    public class Customer : IEntity<int>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        public Customer()
        {
            this.Disabled = false;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the person type.
        /// </summary>
        [ForeignKey("CustomerTypeId")]
        public CustomerType CustomerType { get; set; }

        /// <summary>
        /// Gets or sets the person type id.
        /// </summary>
        public int CustomerTypeId { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        [MaxLength(100)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        [MaxLength(100)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the address line 1.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the address line 2.
        /// </summary>
        [MaxLength(300)]
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the post code.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string PostCode { get; set; }

        /// <summary>
        /// Gets or sets the mobile phone.
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Gets or sets the tele phone.
        /// </summary>
        public string TelePhone { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether disabeld.
        /// </summary>
        public bool Disabled { get; set; }

        #endregion
    }
}