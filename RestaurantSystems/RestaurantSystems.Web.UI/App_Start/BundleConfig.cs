//  *********************************************************************************************************************
//  <copyright file="BundleConfig.cs" company="Abdul Aziz">
//      Copyright (c) Abdul Aziz. All rights reserved.
//  </copyright>
//  <summary></summary>
//  *********************************************************************************************************************
//   Assembly         : RestaurantSystems.Web.UI
//   Author           : Abdul Aziz
//   Created          : 14-08-2014
//   Last Modified By : Abdul Aziz
//   Last Modified On : 08-09-2014
//  *********************************************************************************************************************
namespace RestaurantSystems.Web.UI
{
    #region imports

    using System.Web.Optimization;

    #endregion

    /// <summary>
    /// The bundle config.
    /// </summary>
    public class BundleConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// The register bundles.
        /// </summary>
        /// <param name="bundles">
        /// The bundles.
        /// </param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            // JQUERY
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-2.1.1.js"));

            // MORDERNIZR
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            // SITE CSS 
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css", new CssRewriteUrlTransform()));

            // SITE SCRIPT
            bundles.Add(new StyleBundle("~/bundles/app").Include("~/Scripts/Main.js", new CssRewriteUrlTransform()));

            // BOOTSTRAP
            bundles.Add(
                new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));

            bundles.Add(
                new StyleBundle("~/Content/bootstrap").Include("~/Content/bootstrap.css", new CssRewriteUrlTransform()));

            // JQUERY COLORS
            bundles.Add(
                new ScriptBundle("~/bundles/flot").Include("~/Scripts/jquery.flot.*", "~/Scripts/jquery.colorhelpers.*"));

            // BOOTSTRAP VALIDATOR
            bundles.Add(new ScriptBundle("~/bundles/bootstrapvalidator").Include("~/Scripts/bootstrapValidator.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrapvalidator").Include("~/Content/bootstrapValidator.css"));

            // BOOTSTRAP DATE TIME
            bundles.Add(
                new ScriptBundle("~/bundles/bootstrapdatetimepicker").Include("~/Scripts/moment.js")
                    .Include("~/Scripts/bootstrap-datetimepicker.min.js"));

            bundles.Add(
                new StyleBundle("~/Content/bootstrapdatetimepicker").Include(
                    "~/Content/bootstrap-datetimepicker.min.css"));

            // BOOTSTRAP TREE VIEW
            bundles.Add(new ScriptBundle("~/bundles/bootstraptree").Include("~/Scripts/bootstrap-treeview.js"));

            bundles.Add(new StyleBundle("~/Content/bootstraptree").Include("~/Content/bootstrap-treeview.css"));

            BundleTable.EnableOptimizations = true;
        }

        #endregion
    }
}