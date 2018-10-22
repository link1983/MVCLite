using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLite.Areas.Manage.ViewModels;
using MVCLite.Utility;

namespace MVCLite.Areas.Manage.Controllers
{
    public class SettingController : ManageBaseController
    {
        // GET: Manage/Setting
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Config info)
        {
            string xml = XmlUtil.Serializer(typeof(Config), info);
            return View();
        }
    }
}