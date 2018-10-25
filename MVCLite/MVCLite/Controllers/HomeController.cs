using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace MVCLite.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        private readonly DAL.Article dal = new DAL.Article();

        public ActionResult Index()
        {
            ViewBag.List = GetModelList("");
            return View();
        }
        public ActionResult Add()
        {
            return View();
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