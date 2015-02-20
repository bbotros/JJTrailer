using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class Category
    {
        //general
        public Guid ID { get; set; }
        public string Name { get; set; }
         [UIHint("Redactor")]    
        [DataType(DataType.Html)]
        [AllowHtml]

        public string Description { get; set; }
        public string MetaTagDescription { get; set; }
        public string MetaTagKeywords { get; set; }

        //data
        public Guid? CategoryImageID { get; set; }
        public Guid? CategoryID { get; set; }
        public bool Status { get; set; }
    }
}