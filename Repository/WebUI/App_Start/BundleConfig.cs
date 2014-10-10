using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace WebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/javascript")
            .Include("~/Scripts/jquery-{version}.js",
            "~/Scripts/jquery.validate.js",
            "~/Scripts/jquery.validate.unobtrusive.js",
            "~/Scripts/jquery.unobtrusive-ajax.js",
            "~/Scripts/modernizr-2.8.3.js"));
        }
    }
}