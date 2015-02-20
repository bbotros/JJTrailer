using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class ManufacturerImage
    {
        public Guid ID { get; set; }

        public Guid ManufacturerID { get; set; }
        public Guid ImageManagerID { get; set; }
    
    }
}