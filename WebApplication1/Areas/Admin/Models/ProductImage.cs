using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class ProductImage
    {
        public Guid ID { get; set; }

        public Guid ProductID { get; set; }
        public Guid ImageManagerID { get; set; }
    
    }
}