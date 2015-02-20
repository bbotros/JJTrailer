using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class CategoryImage
    {
        public Guid ID { get; set; }
        public Guid CategoryID { get; set; }
        public Guid ImageManagerID { get; set; }
    
    }
}