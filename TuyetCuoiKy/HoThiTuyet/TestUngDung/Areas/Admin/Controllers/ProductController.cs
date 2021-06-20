using ModelEF.Dao;
using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        HoThiTuyetContext db = new HoThiTuyetContext();
        public ActionResult Index(string searchString)
        {
            var product = new ProductDao();
            var model = product.ListWhereAll(searchString);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            setViewBag();
            return View();
        }
        public void setViewBag(int? selectedID = null)
        {
            var dao = new CategoryDao();
            ViewBag.IDCategory = new SelectList(dao.ListAll(), "ID", "Name", selectedID);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product sp, HttpPostedFileBase Image)
        {


            if (Image != null && Image.ContentLength > 0)
            {
               
                string _FileName = Path.GetFileName(Image.FileName);
                string _path = Path.Combine(Server.MapPath("~/Upload/sanpham/" + _FileName));
                Image.SaveAs(_path);

                sp.Image = _FileName;

            }

            if (ModelState.IsValid)
            {
                db.Product.Add(sp);
                db.SaveChanges();
                SetAlert("Thêm Sản Phẩm Thành Công", "success");
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(System.Int32 id)
        {
            var product = new ProductDao();
            var result = product.FindId(id);
            setViewBag(result.ID);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product sp, HttpPostedFileBase Image)
        {
            Product unv = db.Product.FirstOrDefault(x => x.ID == sp.ID);

            if (unv != null)
            {
                unv.IDCategory = sp.IDCategory;
                unv.Name = sp.Name;
                unv.UnitCost = sp.UnitCost;
                unv.Quantity = sp.Quantity;
                unv.Description = sp.Description;
                unv.Status = sp.Status;
                if (Image != null && Image.ContentLength > 0)
                {
                    int id = sp.ID;

                    string _FileName = "";
                    _FileName = Path.GetFileName(Image.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Upload/sanpham/" + _FileName));
                    Image.SaveAs(_path);
                    unv.Image = _FileName;
                }
            }

            if (ModelState.IsValid)
            {
                db.SaveChanges();
                SetAlert("Cập Nhật Sản Phẩm Thành Công", "success");
                return RedirectToAction("Index");
            }
            setViewBag(sp.ID);
            return View();
        }
        public JsonResult Delete(System.Int32 id)
        {

            var product = new ProductDao();
            bool re = product.Delete(id);
            return Json(re, JsonRequestBehavior.AllowGet);
        }
    }
}