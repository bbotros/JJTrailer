using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJTrailerStore.Areas.Admin.Models
{
    public class ProductInShoppingcart
    {
        //general
        public Guid ShoppingCartID { get; set; }
        public Guid ProductID { get; set; }
        public DateTime TimeAdded { get; set; }
        public int Quantity { get; set; }
    }
}