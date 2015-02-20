using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class Tax
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public float Percentage { get; set; }

    }
}