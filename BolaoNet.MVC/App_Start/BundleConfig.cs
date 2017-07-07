using System.Web;
using System.Web.Optimization;

namespace BolaoNet.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));













            //-------------------------------------------------------
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Content/vendor/jquery/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Content/vendor/jquery/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/metisMenujs").Include(
            //    "~/Content/vendor/metisMenu/metisMenu.js"));

            //bundles.Add(new ScriptBundle("~/bundles/morrisjs").Include(
            //    "~/Content/vendor/raphael/raphael.js",
            //    "~/Content/vendor/morrisjs/morrisjs.js",
            //    "~/Content/data/morris-data.js"
            //    ));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Content/vendor/modernizr/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
            //          "~/Content/vendor/bootstrap/js/bootstrap.js",
            //          "~/Content/vendor/bootstrap/js/respond.js"));

            //bundles.Add(new ScriptBundle("~/bundles/sitejs").Include(
            //          "~/Content/js/sb-admin-2.js"));

            //bundles.Add(new StyleBundle("~/bundles/bootstrapcss").Include(
            //        "~/Content/vendor/bootstrap/css/bootstrap.css"
            //    ));

            //bundles.Add(new StyleBundle("~/bundles/metisMenucss").Include(
            //        "~/Content/vendor/metisMenu/metisMenu.css"
            //    ));

            //bundles.Add(new StyleBundle("~/bundles/sitecss").Include(
            //        "~/Content/vendor/morrisjs/morris.css"
            //    ));

            //bundles.Add(new StyleBundle("~/bundles/morriscss").Include(
            //        "~/Content/css/sb-admin-2.css"
            //    ));

            //bundles.Add(new StyleBundle("~/bundles/font-awesome").Include(
            //        "~/Content/vendor/font-awesome/css/font-awesome.min.css"
            //    ));











            //-------------------------------------------------------

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                //"~/Content/js/jquery-{version}.js"));
                 "~/Content/js/jquery-2.1.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/js/jquery.validate*"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/js/modernizr-*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Content/js/modernizr.tivit2*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/js/bootstrap.min.js",
                      "~/Content/js/respond.js",
                      "~/Content/js/bootstrap-datepicker.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/font-awesome/css/font-awesome.css",
                      "~/Content/css/animate.css",
                      "~/Content/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/css8").Include(
                "~/Content/font-awesome/css/font-awesome-ie7.css",
                "~/Content/css/ie8-and-down.css"));

            bundles.Add(new ScriptBundle("~/bundles/metisMenu").Include(
                      "~/Content/js/plugins/metisMenu/jquery.metisMenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/slimscroll").Include(
                      "~/Content/js/plugins/slimscroll/jquery.slimscroll.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Content/js/inspinia.js",
                      "~/Content/js/plugins/pace/pace.min.js"));






            bundles.Add(new ScriptBundle("~/bundles/jcrop").Include(
                  "~/Content/js/jquery.jcrop.min.js"));
            bundles.Add(new StyleBundle("~/Content/jcrop").Include(
               "~/Content/css/ie8-and-down.css"));




            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
