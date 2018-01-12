using System.Web.Optimization;

namespace DevaxiloS.Web.FrontEnd
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterOutsiteBundles(bundles);
            RegisterAppBundles(bundles);
        }

        private static void RegisterOutsiteBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/login_css")
                .Include("~/Assets/css/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/css/font-awesome.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/css/openSansFont.css", new CssRewriteUrlTransform())
                .Include("~/Assets/css/user.css", new CssRewriteUrlTransform())
                .Include("~/Assets/css/custom.css", new CssRewriteUrlTransform())
            );

            bundles.Add(new ScriptBundle("~/bundles/login_js")
                .Include("~/Scripts/jquery.validate.min.js"
                    , "~/Scripts/jquery.validate.unobtrusive.min.js"
                    , "~/Assets/js/bootstrap.min.js"
                    , "~/Assets/js/outsite_action_url.js"
                    , "~/Assets/js/common.js")
            );
        }

        private static void RegisterAppBundles(BundleCollection bundles)
        {
            
            bundles.Add(new StyleBundle("~/bundles/app_css")
                .Include("~/Assets/css/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/css/font-awesome.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/css/openSansFont.css", new CssRewriteUrlTransform())
                .Include("~/Assets/css/select2.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/css/daterangepicker.css", new CssRewriteUrlTransform())
                .Include("~/Assets/css/user.css", new CssRewriteUrlTransform())
                .Include("~/Assets/css/custom.css", new CssRewriteUrlTransform())
            );

            bundles.Add(new ScriptBundle("~/bundles/app_jq_validate_js")
                .Include("~/Scripts/jquery.validate.min.js"
                    , "~/Scripts/jquery.validate.unobtrusive.min.js")
            );

            bundles.Add(new ScriptBundle("~/bundles/app_js")
                .Include("~/Assets/js/bootstrap.min.js"
                    , "~/Assets/js/bootstrap-confirmation.js"
                    , "~/Assets/js/knockout-3.4.2.js"
                    , "~/Assets/js/knockout.mapping.js"
                    , "~/Assets/js/knockstrap.min.js"
                    , "~/Assets/js/lodash.js"
                    , "~/Assets/js/moment.min.js"
                    , "~/Assets/js/select2.min.js"
                    , "~/Assets/js/daterangepicker.js"
                    , "~/Assets/js/action_url.js"
                    , "~/Assets/js/common.js")
            );
        }
    }
}
