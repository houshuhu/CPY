using System.Web.Mvc;

namespace CPy.Web.Areas.Layout
{
    public class LayoutAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Layout";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Layout_default",
                "Layout/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}