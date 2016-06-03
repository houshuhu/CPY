using System.Web;
using System.Web.Optimization;

namespace CPy.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;
            //加载easyui默认样式
            bundles.Add(new StyleBundle("~/easyui/css").Include(
                      "~/Content/jquery-easyui-1.4.5/themes/default/easyui.css",
                      "~/Content/jquery-easyui-1.4.5/themes/icon.css",
                      "~/Content/jquery-easyui-1.4.5/themes/own-icon.css",
                      "~/Content/less/main.layout.common.css"));

            //加载必需脚本
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Content/jquery-easyui-1.4.5/jquery.min.js",
                      "~/Content/jquery-easyui-1.4.5/jquery.easyui.min.js",
                      "~/Content/Scripts/Common.js"));
        }
    }
}
