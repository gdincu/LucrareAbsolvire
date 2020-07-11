using Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try {
            if(!context.ChargingPointLocations.Any())
                {
                    var locationsData = File.ReadAllText("../Infrastructure/Data/SeedData/locations.json");
                    var locations = JsonConvert.DeserializeObject<List<ChargingPointLocation>>(locationsData);
                    foreach (ChargingPointLocation item in locations)
                        context.ChargingPointLocations.Add(item);
                    await context.SaveChangesAsync();
                }

            if (!context.ChargingPointTypes.Any())
                {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonConvert.DeserializeObject<List<ChargingPointType>>(typesData);
                    foreach (ChargingPointType item in types)
                        context.ChargingPointTypes.Add(item);
                    await context.SaveChangesAsync();
                }

             if (!context.ChargingPoints.Any())
                 {
                     var pointsData = File.ReadAllText("../Infrastructure/Data/SeedData/chargingPoints.json");
                     var points = JsonConvert.DeserializeObject<List<ChargingPoint>>(pointsData);
                     foreach (ChargingPoint item in points)
                         context.ChargingPoints.Add(item);
                     await context.SaveChangesAsync();
                 }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
