using ModelEF.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class DetailProductController : Controller
    {
        // GET: Admin/DetailProduct
        public ActionResult Index(System.Int32 id)
        {
            var product_detail = new DetailProductDao();
            var model = product_detail.ListWhereAll(id);
            return View(model);
        }
    }
}