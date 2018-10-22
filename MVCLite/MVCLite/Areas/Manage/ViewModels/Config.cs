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
        [StringLength(25,MinimumLength =3,ErrorMessage ="长度在3到25之间")]
        public string stitle { set; get; }
        [Required]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "长度在3到16之间")]
        public string name { set; get; }
        public string avatar { set; get; }
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "长度在3到150之间")]
        public string surl { set; get; }
        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "长度在3到250之间")]
        public string sentitle { set; get; }
        public string skeywords { set; get; }
        [Required]
        [StringLength(400, MinimumLength = 3, ErrorMessage = "长度在3到400之间")]
        public string sdescription { set; get; }

        public string s_qq { set; get; }

        public string s_qqu { set; get; }
        public string s_email { set; get; }
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "长度在3到150之间")]
        public string s_address { set; get; }
        [Required]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "长度在3到150之间")]
        public string scopyright { set; get; }


    }
}