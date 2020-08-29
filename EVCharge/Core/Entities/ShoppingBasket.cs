using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class ShoppingBasket
    {
        public ShoppingBasket()
        {
        }

        public ShoppingBasket(String id)
        {
            Id = id;
        }

        public string Id { get; set; }
        //public List<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
        public List<PurchaseItem> PurchaseItems { get; set; } 
    }
}
