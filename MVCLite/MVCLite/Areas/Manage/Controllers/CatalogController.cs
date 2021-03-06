﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace MVCLite.Areas.Manage.Controllers
{
    public class CatalogController : ManageBaseController
    {
        private readonly DAL.Catalog dal = new DAL.Catalog();

        // GET: Manage/Catalog
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
        public ActionResult Add(ViewModels.CatalogAdd info)
        {
            if(ModelState.IsValid)
            {
                var model = new Models.Catalog();
                model.ID = dal.GetMaxId();
                model.AddTime = DateTime.Now;
                model.Intro = "";
                model.Modifytime = DateTime.Now;
                model.Name = info.Name;
                model.Status = 1;
                dal.Add(model);
                return Redirect("/manage/catalog/index");
            }

            return View(info);

        }

        public List<MVCLite.Models.Catalog> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MVCLite.Models.Catalog> DataTableToList(DataTable dt)
        {
            List<MVCLite.Models.Catalog> modelList = new List<MVCLite.Models.Catalog>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MVCLite.Models.Catalog model;
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