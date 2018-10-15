using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLite.Areas.Manage.Controllers
{
    public class HomeController : ManageBaseController
    {
        // GET: Manage/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}