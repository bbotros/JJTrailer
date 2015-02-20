using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class TaxClass
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Percentage { get; set; }

    }
}