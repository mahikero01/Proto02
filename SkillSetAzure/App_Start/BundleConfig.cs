using System.Web;
using System.Web.Optimization;

namespace SkillSetAzure
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/styles.24f154a169d9024f2b08.bundle.css"));


            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                        "~/Scripts/inline.403ce165287b48588036.bundle.js",
                        "~/Scripts/polyfills.f7b874881570ebababa5.bundle.js",
                        "~/Scripts/scripts.35583b669d2fd19a88da.bundle.js",
                        "~/Scripts/vendor.e2c7bdd2342cb9c54abb.bundle.js",
                        "~/Scripts/main.7554ab6f899b44b76829.bundle.js"));
        }
    }
}
