using System.Web.Mvc;
using System.Web.Routing;

namespace QLSV.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("login", "dang-nhap", new { controller = "Login", action = "Index" });
            routes.MapRoute("xemdiem", "xem-diem-thi", new { controller = "Home", action = "Xemdiem" });
            routes.MapRoute("dangky", "dang-ky-thi", new { controller = "Home", action = "Dangky" });
            routes.MapRoute("tintuc", "tin-tuc", new { controller = "Home", action = "Tintuc" });
            routes.MapRoute("hoidap", "hoi-dap", new { controller = "Home", action = "Hoidap" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute("Ajax", "Ajax/{Controller}/{action}", new { controller = "Home", action = "Index" }, new[] { "QLSV.Controllers" });
        }
    }
}