using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLite.Areas.Manage.ViewModels
{
    public class Config
    {
        [Required]
        public string stitle { set; get; }
        public string name { set; get; }
        public string surl { set; get; }

        public string sentitle { set; get; }
        public string skeywords { set; get; }

        public string sdescription { set; get; }

        public string s_qq { set; get; }

        public string s_qqu { set; get; }
        public string s_email { set; get; }
        public string s_address { set; get; }
        public string scopyright { set; get; }


    }
}