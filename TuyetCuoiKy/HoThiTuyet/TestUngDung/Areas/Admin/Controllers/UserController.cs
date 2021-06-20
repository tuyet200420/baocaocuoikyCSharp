using ModelEF.Dao;
using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListWhereAll(searchString,page,pagesize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create(string user)
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(UserAccount model)
        {

            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                //var user = dao.FindId(model.admin_id);
                var pass = Encryptor.EncryptMD5(model.PassWord);
                model.PassWord = pass;
                string result = dao.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Thêm tài khoản thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    SetAlert("Thêm tài khoản thất bại", "error");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(System.Int32 id)
        {
            var dao = new UserDao();
            var result = dao.FindId(id);
            if (result != null)
                return View(result);
            return View();
        }
        [HttpPost]

        public ActionResult Edit(UserAccount model)
        {
            var dao = new UserDao();
            var pass = Encryptor.EncryptMD5(model.PassWord);
            model.PassWord = pass;
            string result = dao.Update(model);
            if (!string.IsNullOrEmpty(result))
            {
                SetAlert("Cập nhật tài khoản thành công", "success");
                return RedirectToAction("Index", "User");
            }
            else
            {
                SetAlert("Cập nhật tài khoản thất bại", "error");
            }
            return View();
        }
        public JsonResult Delete(System.Int32 id)
        {

            var dao = new UserDao();
            bool re = dao.Delete(id);
            return Json(re, JsonRequestBehavior.AllowGet);
        }
    }
}