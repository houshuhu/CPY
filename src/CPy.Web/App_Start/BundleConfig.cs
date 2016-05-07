using System.Web;
using System.Web.Optimization;

namespace CPy.Web
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //加载easyui默认样式
            bundles.Add(new StyleBundle("~/easyui/css").Include(
                      "~/Content/jquery_easyui/themes/default/easyui.css",
                      "~/Content/jquery_easyui/themes/icon.css"));

            //加载必需脚本
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Content/jquery_easyui/jquery.min.js",
                      "~/Content/jquery_easyui/jquery.easyui.min.js",
                      "~/Content/Scripts/Common.js"));
        }
    }
}
