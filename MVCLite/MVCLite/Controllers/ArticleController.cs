using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCLite.Controllers
{
    public class ArticleController:BaseController
    {
        private readonly DAL.Article dal = new DAL.Article();

        public ActionResult Index(int ID)
        {
            var model = dal.GetModel(ID);
            if(model==null)
            {
                return Content("文章不存在");
            }
            return View(model);
        }
    }
}