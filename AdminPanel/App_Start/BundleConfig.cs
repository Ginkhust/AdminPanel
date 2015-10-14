using System.Web;
using System.Web.Optimization;

namespace AdminPanel
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Styles/css").Include(
                    "~/Content/vendor/fontawesome/css/font-awesome.css",
                    "~/Content/vendor/metisMenu/dist/metisMenu.css",
                    "~/Content/vendor/animate.css/animate.css",
                    "~/Content/vendor/bootstrap/dist/css/bootstrap.css",
                    "~/fonts/pe-icon-7-stroke/css/pe-icon-7-stroke.css",
                    "~/fonts/pe-icon-7-stroke/css/helper.css",
                    "~/Content/styles/style.css"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                    "~/Content/vendor/jquery/dist/jquery.min.js",
                    "~/Content/vendor/jquery-ui/jquery-ui.min.js",
                    "~/Content/vendor/slimScroll/jquery.slimscroll.min.js",
                    "~/Content/vendor/bootstrap/dist/js/bootstrap.min.js",
                    "~/Content/vendor/jquery-flot/*.js",
                    "~/Content/vendor/flot.curvedlines/curvedLines.js",
                    "~/Content/vendor/jquery.flot.spline/index.js",
                    "~/Content/vendor/metisMenu/dist/metisMenu.min.js",
                    "~/Content/vendor/iCheck/icheck.min.js",
                    "~/Content/vendor/peity/jquery.peity.min.js",
                    "~/Content/vendor/sparkline/index.js",
                    "~/Scripts/homer.js",
                    "~/Scripts/charts.js"
                ));
            bundles.Add(new ScriptBundle("~/Styles/css/editor").Include(
                   "~/Content/vender/summernote/dist/summernote.css",
                    "~/Content/vender/summernote/dist/summernote-bs3.css"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/js/editor").Include(
                "~/Content/vendor/summernote/dist/summernote.min.js"
                ));
        }
    }
}
