using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Specifications
{
    public class ChargingPointsWithTypesAndLocationsSpecification : BaseSpecification<ChargingPoint>
    {
        public ChargingPointsWithTypesAndLocationsSpecification(string sort)
        {
            AddInclude(x => x.ChargingPointType);
            AddInclude(x => x.ChargingPointLocation);

            if(!string.IsNullOrEmpty(sort))
            {
                switch (sort.ToLower())
                {
                    //Order by location
                    case "locationasc":
                        AddOrderBy(x => x.ChargingPointLocation.Name);
                        break;
                    case "locationdesc":
                        AddOrderByDescending(x => x.ChargingPointLocation.Name);
                        break;
                    //Order by type
                    case "typeasc":
                        AddOrderBy(x => x.ChargingPointType.Name);
                        break;
                    case "typedesc":
                        AddOrderByDescending(x => x.ChargingPointType.Name);
                        break;
                    //Order by price
                    case "priceasc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "pricedesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    //Default order by
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ChargingPointsWithTypesAndLocationsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ChargingPointType);
            AddInclude(x => x.ChargingPointLocation);
        }
    }
}
