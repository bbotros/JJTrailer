using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class Dimension
    {
        public Guid ID { get; set; }
        public float Lenght { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public Guid DimensionClassID { get; set; }
    }
}