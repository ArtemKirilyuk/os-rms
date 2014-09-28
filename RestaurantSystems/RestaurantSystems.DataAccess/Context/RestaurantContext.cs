//  *********************************************************************************************************************
//  <copyright file="RestaurantContext.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.DataAccess
//   Author           : Abdul Aziz
//   Created          : 03-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 13-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.DataAccess.Context
{
    #region imports

    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using RestaurantSystems.Core.User;
    using RestaurantSystems.DataAccess.Model;
    using RestaurantSystems.Logs;

    #endregion

    /// <summary>
    ///     The restaurant context.
    /// </summary>
    public class RestaurantContext : IdentityDbContext<User>
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RestaurantContext" /> class.
        /// </summary>
        public RestaurantContext()
            : base("Restaurant")
        {
            RestaurantLogger<RestaurantContext>.Info("Creating new restaurant context...");
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the customers.
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; }

        /// <summary>
        ///     Gets or sets the person types.
        /// </summary>
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }

        /// <summary>
        ///     Gets or sets the products.
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        ///     Gets or sets the order headers.
        /// </summary>
        public virtual DbSet<OrderHeader> OrderHeaders { get; set; }

        /// <summary>
        ///     Gets or sets the order details.
        /// </summary>
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        ///     Gets or sets the bookings.
        /// </summary>
        public virtual DbSet<Booking> Bookings { get; set; }

        /// <summary>
        ///     Gets or sets the product categories.
        /// </summary>
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            RestaurantLogger<RestaurantContext>.Info("Building context model relationships");

            modelBuilder.Properties<int>().Where(x => x.Name == "Id").Configure(y => y.IsKey());

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            // user to role relationship.
            modelBuilder.Entity<User>().HasMany<IdentityUserRole>(u => u.Roles);

            // user roles
            modelBuilder.Entity<IdentityUserRole>().HasKey(iur => new { iur.UserId, iur.RoleId }).ToTable("UserRoles");

            // user logins
            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(iul => new { iul.UserId, iul.LoginProvider, iul.ProviderKey })
                .ToTable("UserLogins");

            // user claims
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");

            // roles.
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").Property(ir => ir.Name).IsRequired();

            RestaurantLogger<RestaurantContext>.Info("Completed building context model relationships");
        }

        #endregion
    }
}