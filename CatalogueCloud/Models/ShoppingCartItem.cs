using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogueCloud.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Product Product { get; set; }
        public decimal Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
