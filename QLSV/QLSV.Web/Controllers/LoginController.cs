using System.Data;
using System.Web.Mvc;
using System.Web.Security;
using EduSoft.Utils;
using QLSV.Web.Common;
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
            var usernew = Connect.sp_checkData(user.Username.ToString(), PasswordUtil.HashPassword(user.Password));
            foreach (DataRow row in usernew.Rows)
            {
                FormsAuthentication.SetAuthCookie(row["MaSV"] + "|" + row["HoTenSV"] + "|" + row["Malop"] + "|" + row["NgaySinh"] + "|" + row["MatKhau"], true);
            }
            return Redirect("/");
        }
        
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

    }
}
