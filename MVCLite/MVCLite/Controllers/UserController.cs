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

            var model = new Models.User();
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