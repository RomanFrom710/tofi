using System.Web.Optimization;
using BundleTransformer.Core.Bundles;

namespace TOFI.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts/vendor").Include(
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/jquery.validate*",
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/scripts/my").Include(
                "~/Scripts/My/enable-datepicker.js",
                "~/Scripts/My/fix-stupid-chrome-bug.js"));

            bundles.Add(new CustomStyleBundle("~/styles").Include(
                      "~/Content/style/main.less"));
        }
    }
}
