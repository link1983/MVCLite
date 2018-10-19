using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLite.Areas.Manage.Controllers
{
    [Authorize(Roles ="manager")]
    public class ManageBaseController : Controller
    {
        // GET: Manage/ManageBase

    }
}