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
            string xml = System.IO.File.ReadAllText(Request.PhysicalApplicationPath+"\\config\\websetting.config");
            var info = XmlUtil.Deserialize(typeof(Config), xml);
            return View(info);
        }
        [HttpPost]
        public ActionResult Index(ViewModels.Config info)
        {
            string xml = XmlUtil.Serializer(typeof(Config), info);
            System.IO.File.WriteAllText(Request.PhysicalApplicationPath+"\\config\\websetting.config",xml);

            return Redirect("/manage/setting/index");
        }
    }
}