using System.Linq;
using System.Web.Mvc;
using QLSV.Base;

namespace QLSV.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.name = User.Identity.Name.Split('|')[0];
                return View();
            }
            return Redirect("/dang-nhap");
        }
        
        public ActionResult Login()
        {
            return View();
        }

    }
}
