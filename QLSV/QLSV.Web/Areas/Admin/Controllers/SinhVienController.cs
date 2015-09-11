using System.Web.Mvc;

namespace QLSV.Web.Areas.Admin.Controllers
{
    public class SinhVienController : Controller
    {
        //
        // GET: /Admin/SinhVien/

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ListItems()
        {
            return View();
        }

        public string Indexpage()
        {
            var a = Request["Page"];
            var b = Request["Row"];
            return (a + b);
        }

    }
}
