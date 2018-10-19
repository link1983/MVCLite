using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLite.Controllers
{
    public class UserController : BaseController
    {
        private readonly DAL.User dal = new DAL.User();
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name,string password)
        {
            if (string.IsNullOrEmpty(name) || name.Length > 16 || name.Length < 3)
            {
                return Content("账号密码格式错误！");
            }
            if (string.IsNullOrEmpty(password) || password.Length > 16 || password.Length < 6)
            {
                return Content("账号密码格式错误！");
            }
            var user = dal.GetModel(name);
            if(user==null||user.password!=password)
            {
                return Content("账号或密码不正确！");
            }

            Session["login_user"] = user;
            return Redirect("/");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string name,string password)
        {
            if(string.IsNullOrEmpty(name)||name.Length>16||name.Length<3)
            {
                return Content("账号密码错误！");
            }
            if (string.IsNullOrEmpty(password) || password.Length > 16 || password.Length < 6)
            {
                return Content("账号密码错误！");
            }
            var user = dal.GetModel(name);
            if(user!=null)
            {
                ModelState.AddModelError("name", name + "账号已存在");
                return View();
            }

            var model = new Models.User();
            model.ID = dal.GetMaxId() + 1;
            model.name = name;
            model.password = password;
            model.Modifytime = DateTime.Now;
            model.AddTime = DateTime.Now;
            model.status = 1;
            var isSuccess = dal.Add(model);
            if(isSuccess)
            {
                return Redirect("/");
            }
            else
            {
                return Content("注册失败");
            }
        }
    }
}