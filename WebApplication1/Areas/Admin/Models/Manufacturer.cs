using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class Manufacturer
    {
        //general
        public Guid ID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Html)]
        public string Description { get; set; }
        public string MetaTagDescription { get; set; }
        public string MetaTagKeywords { get; set; }

        //data
        public Guid ManufacturerImageID { get; set; }
        public bool Status { get; set; }
    }
}