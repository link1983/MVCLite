using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLite.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name,string password)
        {
            if((name??"")!="manage"||(password??"")!="manage")
            {
                return Content("账户或密码错误");
            }
            else
            {
                Utility.TicketTool.SetCookie(name, "manager");
                return Redirect("/manage/home/index");
            }
        }
    }
}