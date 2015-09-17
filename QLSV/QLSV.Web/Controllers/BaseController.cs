using System;
using System.Linq;
using System.Web.Mvc;
using QLSV.Base;
using QLSV.Web.Common;
using QLSV.Web.Models;

namespace QLSV.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly DatabaseContainer QlsvEntities = new DatabaseContainer();
        private readonly Util _util = new Util();
        protected Aspuser Sinhvien
        {
            get
            {
                var svnew = new Aspuser();
                var sv = User.Identity.Name.Split('|');
                if (sv.Length <= 0) return svnew;
                svnew.Username = int.Parse(sv[0]);
                svnew.HoTen = sv[1];
                svnew.Lop = sv[2];
                svnew.NgaySinh = sv[3];
                svnew.Password = sv[4];
                svnew.IsDangky = _util.Checkdangky();
                var spMaxSinhVienResult = QlsvEntities.sp_MaxSinhVien(int.Parse(sv[0])).FirstOrDefault();
                if (spMaxSinhVienResult == null) return svnew;
                if (spMaxSinhVienResult.Diem != null) svnew.DiemThi = (double) spMaxSinhVienResult.Diem;
                return svnew;
            }
        }

    }
}
