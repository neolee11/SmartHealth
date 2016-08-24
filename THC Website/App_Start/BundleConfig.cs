using System.Web;
using System.Web.Optimization;

namespace THC_Website
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

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                 "~/Scripts/jquery-2.1.3.min.js",
                 "~/Scripts/jquery-ui-1.11.4.min.js",
                 "~/Scripts/jquery.validate.min.js",
                 "~/Scripts/bootstrap.min.js",
                 "~/Scripts/owl.carousel.min.js",
                 "~/Scripts/jquery.superslides.min.js",
                 "~/Scripts/retina-1.1.0.min.js",
                 "~/Scripts/wow.min.js",
                 "~/Scripts/jquery.cubeportfolio.min.js",
                 "~/Scripts/jquery.fitvids.js",
                 "~/Scripts/smooth-scroll.js",
                 "~/Scripts/jquery.magnific-popup.js",
                 "~/Scripts/main.js",
                 "~/Scripts/moment.js",
                 "~/Scripts/lodash.min.js",
                 "~/Scripts/app/appointmentPlusAPI.js",
                 "~/Scripts/app/userSession.js",
                 "~/Scripts/app/userAccountManagement.js",
                 "~/Scripts/app/patientManagement.js"
                ));

            bundles.Add(new StyleBundle("~/styles/css").Include(
                "~/styles/jquery-ui.min.css",
                "~/styles/bootstrap.css",
                "~/styles/animate.min.css",
                "~/styles/owl.theme.css",
                "~/styles/owl.carousel.css",
                "~/styles/superslides.css",
                "~/styles/cubeportfolio.min.css",
                "~/styles/magnific-popup.css",
                "~/styles/reset.css",
                "~/styles/style.css"
                ));
            //"~/styles/site.css"

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
