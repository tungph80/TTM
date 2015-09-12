using System.Web.Mvc;
using System.Web.Security;
using QLSV.Web.Models;

namespace QLSV.Web.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Aspuser user)
        {
            FormsAuthentication.SetAuthCookie(user.Username+"|"+user.Password, true);
            return Redirect("/");
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

    }
}
