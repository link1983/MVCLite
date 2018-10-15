using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLite.Areas.Manage.Controllers
{
    public class SettingController : ManageBaseController
    {
        // GET: Manage/Setting
        public ActionResult Index()
        {
            return View();
        }
    }
}