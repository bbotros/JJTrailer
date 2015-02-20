using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class ImageManager
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string MetaTagDescription { get; set; }
    }
}