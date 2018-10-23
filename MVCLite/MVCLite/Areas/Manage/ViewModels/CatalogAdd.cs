using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MVCLite.Areas.Manage.ViewModels
{
    public class CatalogAdd
    {
        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "长度在3到25之间")]
        public string Name { set; get; }
    }
}