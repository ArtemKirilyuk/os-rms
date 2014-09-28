//  ***********************************************************************
//  <copyright file="ReceiptEntity.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  ***********************************************************************
//   Assembly         : RestaurantSystems.Core.Entities
//   Author           : Abdul Aziz
//   Created          : 10-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 10-08-2014
//  ***********************************************************************
namespace RestaurantSystems.Core.Entities
{
    /// <summary>
    /// The print entity.
    /// </summary>
    public class ReceiptEntity : OrderHeaderEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the sub title 1.
        /// </summary>
        public string SubTitle1 { get; set; }

        /// <summary>
        /// Gets or sets the sub title 2.
        /// </summary>
        public string SubTitle2 { get; set; }
        
        #endregion
    }
}