using System.Collections.Generic;

namespace API.Dtos
{
    public class ChargingPointToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string ChargingPointType { get; set; }
        public string ChargingPointLocation { get; set; }
        //public IEnumerable<ChargingPointToReturnDto> Photos { get; set; }
    }
}