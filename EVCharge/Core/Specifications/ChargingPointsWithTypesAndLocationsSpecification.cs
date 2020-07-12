using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public class ChargingPointsWithTypesAndLocationsSpecification : BaseSpecification<ChargingPoint>
    {
        public ChargingPointsWithTypesAndLocationsSpecification()
        {
            AddInclude(x => x.ChargingPointType);
            AddInclude(x => x.ChargingPointLocation);
        }

        public ChargingPointsWithTypesAndLocationsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ChargingPointType);
            AddInclude(x => x.ChargingPointLocation);
        }
    }
}
