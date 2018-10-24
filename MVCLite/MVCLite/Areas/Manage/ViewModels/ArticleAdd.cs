using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCLite.Areas.Manage.ViewModels
{
    public class ArticleAdd
    {
        [Required]
        [StringLength(150)]
        public string Title { set; get; }
        public int CID { set; get; }
        [Required]
        [StringLength(10000)]
        public string Content { set; get; }
    }
}