using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class ShoppingBasketDTO
    {
        [Required]
        public string Id { get; set; }
        public List<PurchaseItemDto> PurchaseItems { get; set; }
    }
}
