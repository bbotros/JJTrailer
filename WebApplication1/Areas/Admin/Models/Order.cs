using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class Order
    {
        //general
        public Guid ID { get; set; }
        public string InvoiceID { get; set; }
        public Guid ShoppingCartID { get; set; }
        public Guid PaymentID { get; set; }
        public Guid ShippingID { get; set; }
        public decimal OrderTotal { get; set; }
        public bool Status { get; set; }
        public string IPAddress { get; set; }
        public string UserBrowser { get; set; }

    }
}