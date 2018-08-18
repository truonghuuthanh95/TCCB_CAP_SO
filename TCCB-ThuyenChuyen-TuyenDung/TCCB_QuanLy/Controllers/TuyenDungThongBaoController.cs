using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TCCB_QuanLy.Controllers
{
    [RoutePrefix("tuyendung")]
    public class TuyenDungThongBaoController : Controller
    {
        // GET: TuyenDungThongBao
        [Route("thongbao")]
        public ActionResult ThongBao()
        {
            return View();
        }
    }
}