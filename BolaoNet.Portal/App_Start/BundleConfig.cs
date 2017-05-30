using System.Web;
using System.Web.Optimization;

namespace BolaoNet.Portal
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Content/js_old/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Content/js_old/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Content/js_old/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Content/js_old/bootstrap.js",
            //          "~/Content/js_old/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/css_old/bootstrap.css",
            //          "~/Content/css_old/site.css"));






            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/vendor/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/vendor/jquery/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/metisMenujs").Include(
                "~/Content/vendor/metisMenu/metisMenu.js"));

            bundles.Add(new ScriptBundle("~/bundles/morrisjs").Include(
                "~/Content/vendor/raphael/raphael.js",
                "~/Content/vendor/morrisjs/morrisjs.js",
                "~/Content/data/morris-data.js"
                ));


            

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/vendor/modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                      "~/Content/vendor/bootstrap/js/bootstrap.js",
                      "~/Content/vendor/bootstrap/js/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/sitejs").Include(
                      "~/Content/js/sb-admin-2.js"));

            bundles.Add(new StyleBundle("~/bundles/bootstrapcss").Include(
                    "~/Content/vendor/bootstrap/css/bootstrap.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/metisMenucss").Include(
                    "~/Content/vendor/metisMenu/metisMenu.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/sitecss").Include(
                    "~/Content/vendor/morrisjs/morris.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/morriscss").Include(
                    "~/Content/css/sb-admin-2.css"
                ));

            bundles.Add(new StyleBundle("~/bundles/font-awesome").Include(
                    "~/Content/vendor/font-awesome/css/font-awesome.min.css"
                ));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/css_old/bootstrap.css",
            //          "~/Content/css_old/site.css"));




            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
