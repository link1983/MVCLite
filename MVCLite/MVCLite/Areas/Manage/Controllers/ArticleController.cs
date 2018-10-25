using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace MVCLite.Areas.Manage.Controllers
{
    public class ArticleController : ManageBaseController
    {
        private readonly DAL.Article dal = new DAL.Article();

        // GET: Manage/Aritcle
        public ActionResult Index()
        {
            ViewBag.List = GetModelList("");
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)] //不对危险字符处理，否者ueditor会提示错误。
        public ActionResult Add(ViewModels.ArticleAdd info)
        {
            if (ModelState.IsValid)
            {
                var model = new Models.Article();
                model.ID = dal.GetMaxId();
                model.AddTime = DateTime.Now;
                model.Content =info.Content;
                model.Modifytime = DateTime.Now;
                model.Title = info.Title;
                model.levelMax = 0;
                model.click = 0;
                model.CID = 2;//分类先写死，正常在前端下拉选择
                dal.Add(model);
                return Redirect("/manage/article/index");
            }

            return View(info);

        }

        public List<MVCLite.Models.Article> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MVCLite.Models.Article> DataTableToList(DataTable dt)
        {
            List<MVCLite.Models.Article> modelList = new List<MVCLite.Models.Article>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MVCLite.Models.Article model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
    }
}