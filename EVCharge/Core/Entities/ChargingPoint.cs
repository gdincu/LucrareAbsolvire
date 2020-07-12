namespace Core.Entities
{
    public class ChargingPoint: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ChargingPointLocation ChargingPointLocation { get; set; }
        public int ChargingPointLocationId { get; set; } 
        public ChargingPointType ChargingPointType { get; set; }
        public int ChargingPointTypeId { get; set; }
}
}
