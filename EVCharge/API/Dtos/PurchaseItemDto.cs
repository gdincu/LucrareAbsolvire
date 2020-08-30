using System;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class PurchaseItemDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(0.1, 999.9, ErrorMessage = "Price needs to be greater than 0!!")]
        public decimal Price { get; set; }
        [Required]
        public DateTime Start { get; set; }
        [Required]
        public DateTime End { get; set; }
        public int Quantity { get; set; }
        [Required]
        public string PhotoURL { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Type { get; set; }
    }
}