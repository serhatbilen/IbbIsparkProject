using System.Web;
using System.Web.Optimization;

namespace SerhatBilenIBB_TestApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
			bundles.Add(new StyleBundle("~/bundles/contentCss").Include("~/Content/style.css"));
			bundles.Add(new StyleBundle("~/css/bootstrap").Include("~/Content/bootstrap.min.css"));

			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

			bundles.Add(
				new ScriptBundle("~/script/Validations")
				.Include(
					"~/Scripts/jquery.validate.min.js",
					"~/Scripts/jquery.validate.unobtrusive.min.js"
				)
			);

			bundles.Add(
				new StyleBundle("~/style/SweetAlert")
				.Include("~/Content/sweetalert/sweetalert2.min.css")
				);

			bundles.Add(new StyleBundle("~/bundles/dataTable").Include("~/Content/dataTables.bootstrap5.min.js"));

            bundles.Add(new ScriptBundle("~/scripts/dataTable").Include("~/Scripts/jquery.dataTables.min.js", "~/Scripts/dataTables.bootstrap5.min.js"));

			bundles.Add(new ScriptBundle("~/scripts/jquery").Include("~/Scripts/jquery-3.6.3.min.js"));
			bundles.Add(new ScriptBundle("~/scripts/popper").Include("~/Scripts/popper.js"));
			bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include("~/Scripts/bootstrap.min.js"));
			bundles.Add(new ScriptBundle("~/scripts/main").Include("~/Scripts/main.js"));
			bundles.Add(new Bundle("~/scripts/bundle").Include("~/Scripts/bootstrap.bundle.min.js"));

			bundles.Add(
				new ScriptBundle("~/script/FontAwesome")
				.Include("~/Content/fontawesome/js/all.min.js")
			);

			bundles.Add(
				new ScriptBundle("~/script/SweetAlert")
				.Include
				("~/Content/sweetalert/sweetalert2.all.min.js",
				"~/Content/sweetalert/sweetalert2.min.js"
				));
		}
    }
}
