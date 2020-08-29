using System;

namespace Core.Entities
{
    public class PurchaseItem
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Quantity { get; set; }
        public string PhotoURL { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
    }
}