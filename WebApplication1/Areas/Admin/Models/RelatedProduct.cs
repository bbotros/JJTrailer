using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class RelatedProduct
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public Guid Product2ID { get; set; }

    }
}