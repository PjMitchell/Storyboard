﻿using System.Web;
using System.Web.Optimization;

namespace Storyboard.Web
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
                      "~/Content/main.css",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-ui/ui-bootstrap.js",
                "~/Scripts/angular-ui/ui-bootstrap-tpls.js"));                                                  
            bundles.Add(new ScriptBundle("~/bundles/Home").Include(
                "~/App/Home/Controllers/SummaryController.js",
                "~/App/Home/Controllers/CreateActorDialogController.js",
                "~/App/Home/Controllers/CreateStoryDialogController.js",
                "~/App/Home/Controllers/StoryOverviewController.js",
                "~/App/Home/Models/AddUpdateStoryCommand.js",
                "~/App/Home/Models/AddUpdateActorCommand.js",
                "~/App/Home/Models/CreateLinkCommand.js",
                "~/App/Home/Services/ActorDataService.js",
                "~/App/Home/Services/LinkDataService.js",
                "~/App/Home/Services/StoryOverviewDataService.js",
                "~/App/Home/Directives/EditField.js"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
