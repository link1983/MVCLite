using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCLite.Utility;

namespace MVCLite.DAL
{
    public class Pagenation
    {
        public void ArticlePager()
        {
            int pageCount = (int) DbHelperSQLite.GetSingle("select count(*) from article");

        }
    }
}