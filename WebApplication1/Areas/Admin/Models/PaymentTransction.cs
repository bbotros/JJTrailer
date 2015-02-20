using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class PaymentTransction
    {
        public Guid ID { get; set; }
        public bool isCompleted { get; set; }
    }
}