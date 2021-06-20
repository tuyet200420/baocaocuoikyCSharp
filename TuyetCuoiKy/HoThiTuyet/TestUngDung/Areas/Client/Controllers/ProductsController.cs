using ModelEF.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Client.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Client/Products
        public ActionResult Index()
        {
            var product = new ProductDao();
            var model = product.ListAll();
            return View(model);
        }
    }
}