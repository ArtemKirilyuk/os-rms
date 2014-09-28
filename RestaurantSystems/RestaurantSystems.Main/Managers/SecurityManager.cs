//  *********************************************************************************************************************
//  <copyright file="SecurityManager.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Main
//   Author           : Abdul Aziz
//   Created          : 13-09-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 13-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Main.Managers
{
    #region imports

    using RestaurantSystems.Core.Manager;
    using RestaurantSystems.Core.UnitOfWork;

    #endregion

    /// <summary>
    ///     The security management.
    /// </summary>
    public class SecurityManager : ISecurityManager
    {
        #region Fields

        /// <summary>
        /// The unit of work.
        /// </summary>
        private IUnitOfWork unitOfWork;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityManager"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        public SecurityManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The is User allowed to access.
        /// </summary>
        /// <param name="controllerName">
        /// The controller name.
        /// </param>
        /// <param name="actionName">
        /// The action name.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsUserAllowedToAccess(string controllerName, string actionName, string name)
        {
            return true;
        }

        #endregion
    }
}