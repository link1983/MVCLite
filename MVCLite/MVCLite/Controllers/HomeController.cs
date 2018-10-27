using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLite.Controllers
{
    public class HomeController : BaseController
    {
        private BLL.ArticleBLL articleBll = new BLL.ArticleBLL();

        public ActionResult Index()
        {
            ViewBag.List = articleBll.GetModelList("");
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }



    }
}