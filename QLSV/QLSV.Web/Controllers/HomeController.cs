using System;
using System.Linq;
using System.Web.Mvc;
using QLSV.Web.Common;
using QLSV.Web.Models;

namespace QLSV.Web.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        //private readonly Util _util = new Util();
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return Redirect("/dang-nhap");

            return View(Sinhvien);
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Menu()
        {
            var model = QlsvEntities.ChuyenMucs.ToList();
            return PartialView(model);
        }

        public ActionResult Xemdiem()
        {
            return PartialView(Sinhvien);
        }
        public ActionResult Dangky()
        {
            //var b = _util.Checkdangky();
            //Sinhvien.IsDangky = b;
            return PartialView(Sinhvien);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Dangkythi()
        {
            //if (!_util.Checkdangky())
            //    return null;
            var obj = new Log();
            try
            {
                var dangKy = new Base.DangKy
                {
                    Masv = Sinhvien.Username,
                    KyNangDoc = false,
                    KyNangNghe = false,
                    DocHieu = false
                };
                UpdateModel(dangKy);
                if (Sinhvien.DiemThi < 200)
                {
                    dangKy.KyNangDoc = false;
                    dangKy.KyNangNghe = false;
                }
                QlsvEntities.DangKies.Add(dangKy);
                QlsvEntities.SaveChanges();
                obj.Error = false;
                obj.Message = "Đăng ký thành công";
            }
            catch (Exception)
            {
                obj.Error = true;
                obj.Message = "Xin thử lại";
            }
            return Json(obj);
        }

        public ActionResult Tintuc()
        {
            return PartialView();
        }
        public ActionResult Hoidap()
        {
            return PartialView();
        }
    }
}
