//  *********************************************************************************************************************
//  <copyright file="RestaurantUserStore.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Main
//   Author           : Abdul Aziz
//   Created          : 10-09-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 13-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Main.Stores
{
    #region imports

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using RestaurantSystems.Core.UnitOfWork;
    using RestaurantSystems.Core.User;

    #endregion

    /// <summary>
    ///     The User store.
    /// </summary>
    public class RestaurantUserStore : IUserStore<User>, 
                                       IUserPasswordStore<User>, 
                                       IUserRoleStore<User>, 
                                       IUserEmailStore<User>, 
                                       IUserPhoneNumberStore<User>, 
                                       IUserTwoFactorStore<User, string>, 
                                       IUserLoginStore<User>, 
                                       IUserLockoutStore<User, string>, 
                                       IUserClaimStore<User, string>, 
                                       IUserSecurityStampStore<User, string>, 
                                       IQueryableUserStore<User, string>
    {
        #region Fields

        /// <summary>
        ///     The user store.
        /// </summary>
        private readonly UserStore<User> userStore;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RestaurantUserStore"/> class.
        ///     Initializes a new instance of the <see cref="UserStore{TUser}"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        public RestaurantUserStore(IUnitOfWork unitOfWork)
        {
            this.userStore = new UserStore<User>(unitOfWork.Context());
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     IQueryable users
        /// </summary>
        public IQueryable<User> Users { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Add a new user claim
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="claim">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task AddClaimAsync(User user, Claim claim)
        {
            return this.userStore.AddClaimAsync(user, claim);
        }

        /// <summary>
        /// Adds a user login with the specified provider and key
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="login">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task AddLoginAsync(User user, UserLoginInfo login)
        {
            return this.userStore.AddLoginAsync(user, login);
        }

        /// <summary>
        /// Adds a user to a role
        /// </summary>
        /// <param name="user">
        /// User name
        /// </param>
        /// <param name="roleName">
        /// Role name
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task AddToRoleAsync(User user, string roleName)
        {
            return this.userStore.AddToRoleAsync(user, roleName);
        }

        /// <summary>
        /// The create async.
        /// </summary>
        /// <param name="userEntity">
        /// The user entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task CreateAsync(User userEntity)
        {
            return this.userStore.CreateAsync(userEntity);
        }

        /// <summary>
        /// The delete async.
        /// </summary>
        /// <param name="userEntity">
        /// The user entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task DeleteAsync(User userEntity)
        {
            return this.userStore.DeleteAsync(userEntity);
        }

        /// <summary>
        ///     The dispose.
        /// </summary>
        public void Dispose()
        {
            this.userStore.Dispose();
        }

        /// <summary>
        /// Returns the user associated with this login
        /// </summary>
        /// <param name="login">
        /// The login.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<User> FindAsync(UserLoginInfo login)
        {
            return this.userStore.FindAsync(login);
        }

        /// <summary>
        /// Returns the user associated with this email
        /// </summary>
        /// <param name="email">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<User> FindByEmailAsync(string email)
        {
            return this.userStore.FindByEmailAsync(email);
        }

        /// <summary>
        /// The find by id async.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<User> FindByIdAsync(string userId)
        {
            return this.userStore.FindByIdAsync(userId);
        }

        /// <summary>
        /// The find by name async.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<User> FindByNameAsync(string userName)
        {
            return this.userStore.FindByNameAsync(userName);
        }

        /// <summary>
        /// Returns the current number of failed access attempts.  This number usually will be reset whenever the password is
        ///     verified or the account is locked out.
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<int> GetAccessFailedCountAsync(User user)
        {
            return this.userStore.GetAccessFailedCountAsync(user);
        }

        /// <summary>
        /// Returns the claims for the user with the issuer set
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IList<Claim>> GetClaimsAsync(User user)
        {
            return this.userStore.GetClaimsAsync(user);
        }

        /// <summary>
        /// Get the user email
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<string> GetEmailAsync(User user)
        {
            return this.userStore.GetEmailAsync(user);
        }

        /// <summary>
        /// Returns true if the user email is confirmed
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<bool> GetEmailConfirmedAsync(User user)
        {
            return this.userStore.GetEmailConfirmedAsync(user);
        }

        /// <summary>
        /// Returns whether the user can be locked out.
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<bool> GetLockoutEnabledAsync(User user)
        {
            return this.userStore.GetLockoutEnabledAsync(user);
        }

        /// <summary>
        /// Returns the DateTimeOffset that represents the end of a user's lockout, any time in the past should be considered
        ///     not locked out.
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<DateTimeOffset> GetLockoutEndDateAsync(User user)
        {
            return this.userStore.GetLockoutEndDateAsync(user);
        }

        /// <summary>
        /// Returns the linked accounts for this user
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user)
        {
            return this.userStore.GetLoginsAsync(user);
        }

        /// <summary>
        /// Get the user password hash
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<string> GetPasswordHashAsync(User user)
        {
            return this.userStore.GetPasswordHashAsync(user);
        }

        /// <summary>
        /// Get the user phone number
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<string> GetPhoneNumberAsync(User user)
        {
            return this.userStore.GetPhoneNumberAsync(user);
        }

        /// <summary>
        /// Returns true if the user phone number is confirmed
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<bool> GetPhoneNumberConfirmedAsync(User user)
        {
            return this.userStore.GetPhoneNumberConfirmedAsync(user);
        }

        /// <summary>
        /// Returns the roles for this user
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<IList<string>> GetRolesAsync(User user)
        {
            return this.userStore.GetRolesAsync(user);
        }

        /// <summary>
        /// Get the user security stamp
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<string> GetSecurityStampAsync(User user)
        {
            return this.userStore.GetSecurityStampAsync(user);
        }

        /// <summary>
        /// Returns whether two factor authentication is enabled for the user
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<bool> GetTwoFactorEnabledAsync(User user)
        {
            return this.userStore.GetTwoFactorEnabledAsync(user);
        }

        /// <summary>
        /// Returns true if a user has a password set
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<bool> HasPasswordAsync(User user)
        {
            return this.userStore.HasPasswordAsync(user);
        }

        /// <summary>
        /// Used to record when an attempt to access the user has failed
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<int> IncrementAccessFailedCountAsync(User user)
        {
            return this.userStore.IncrementAccessFailedCountAsync(user);
        }

        /// <summary>
        /// Returns true if a user is in the role
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="roleName">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<bool> IsInRoleAsync(User user, string roleName)
        {
            return this.userStore.IsInRoleAsync(user, roleName);
        }

        /// <summary>
        /// Remove a user claim
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="claim">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task RemoveClaimAsync(User user, Claim claim)
        {
            return this.userStore.RemoveClaimAsync(user, claim);
        }

        /// <summary>
        /// Removes the role for the user
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="roleName">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task RemoveFromRoleAsync(User user, string roleName)
        {
            return this.userStore.RemoveFromRoleAsync(user, roleName);
        }

        /// <summary>
        /// Removes the user login with the specified combination if it exists
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="login">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task RemoveLoginAsync(User user, UserLoginInfo login)
        {
            return this.userStore.RemoveLoginAsync(user, login);
        }

        /// <summary>
        /// Used to reset the access failed count, typically after the account is successfully accessed
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task ResetAccessFailedCountAsync(User user)
        {
            return this.userStore.ResetAccessFailedCountAsync(user);
        }

        /// <summary>
        /// Set the user email
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="email">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SetEmailAsync(User user, string email)
        {
            return this.userStore.SetEmailAsync(user, email);
        }

        /// <summary>
        /// Sets whether the user email is confirmed
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="confirmed">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SetEmailConfirmedAsync(User user, bool confirmed)
        {
            return this.userStore.SetEmailConfirmedAsync(user, confirmed);
        }

        /// <summary>
        /// Sets whether the user can be locked out.
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="enabled">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SetLockoutEnabledAsync(User user, bool enabled)
        {
            return this.userStore.SetLockoutEnabledAsync(user, enabled);
        }

        /// <summary>
        /// Locks a user out until the specified end date (set to a past date, to unlock a user)
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="lockoutEnd">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SetLockoutEndDateAsync(User user, DateTimeOffset lockoutEnd)
        {
            return this.userStore.SetLockoutEndDateAsync(user, lockoutEnd);
        }

        /// <summary>
        /// Set the user password hash
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="passwordHash">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            return this.userStore.SetPasswordHashAsync(user, passwordHash);
        }

        /// <summary>
        /// Set the user's phone number
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="phoneNumber">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SetPhoneNumberAsync(User user, string phoneNumber)
        {
            return this.userStore.SetPhoneNumberAsync(user, phoneNumber);
        }

        /// <summary>
        /// Sets whether the user phone number is confirmed
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="confirmed">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed)
        {
            return this.userStore.SetPhoneNumberConfirmedAsync(user, confirmed);
        }

        /// <summary>
        /// Set the security stamp for the user
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="stamp">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SetSecurityStampAsync(User user, string stamp)
        {
            return this.userStore.SetSecurityStampAsync(user, stamp);
        }

        /// <summary>
        /// Sets whether two factor authentication is enabled for the user
        /// </summary>
        /// <param name="user">
        /// </param>
        /// <param name="enabled">
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task SetTwoFactorEnabledAsync(User user, bool enabled)
        {
            return this.userStore.SetTwoFactorEnabledAsync(user, enabled);
        }

        /// <summary>
        /// The update async.
        /// </summary>
        /// <param name="userEntity">
        /// The user entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task UpdateAsync(User userEntity)
        {
            return this.userStore.UpdateAsync(userEntity);
        }

        #endregion
    }
}