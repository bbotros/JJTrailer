using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class Payment
    {
        public Guid ID { get; set; }
        public Guid PaymentMethodID { get; set; }
        public Guid PaymentTransactionID { get; set; }
        public bool isPaid { get; set; }
    }
}