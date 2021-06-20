using ModelEF.Dao;
using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var category = new CategoryDao();
            var model = category.ListWhereAll(searchString, page, pagesize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Category model)
        {

            if (ModelState.IsValid)
            {
                var category = new CategoryDao();
                if (category.FindName(model.Name))
                {
                    SetAlert("Danh Mục Đã Tồn Tại!!!", "warning");
                    return RedirectToAction("Create", "Category");
                }
                string result = category.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm danh mục thành công", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    SetAlert("Thêm danh mục thất bại", "error");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(System.Int32 id)
        {
            var category = new CategoryDao();
            var result = category.FindId(id);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]

        public ActionResult Edit(Category model)
        {
            var category = new CategoryDao();
            string result = category.Update(model);
            if (!string.IsNullOrEmpty(result))
            {
                SetAlert("Cập nhật danh mục thành công", "success");
                return RedirectToAction("Index", "Category");
            }
            else
            {
                SetAlert("Cập nhật danh mục thất bại", "error");
            }
            return View();
        }
        public JsonResult Delete(System.Int32 id)
        {

            var category = new CategoryDao();
            bool re = category.Delete(id);
            return Json(re, JsonRequestBehavior.AllowGet);
        }
    }
}