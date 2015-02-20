using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class Shipping
    {
        public Guid ID { get; set; }
        public Guid ShippingMethodID { get; set; }
        public DateTime ShippingPickupDate { get; set; }
        public bool isShipped { get; set; }
        public bool isArrived { get; set; }
        public DateTime ActualArrivalDate { get; set; }
        public DateTime EstimatedArrivalDate { get; set; }

    }
}