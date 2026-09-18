using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ChargingPointRepository : IChargingPointRepository
    {
        private readonly StoreContext _context;

        public ChargingPointRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ChargingPoint>> GetChargingPointsAsync()
        {
            return await _context.ChargingPoints
                .Include(p => p.ChargingPointLocation)
                .Include(p => p.ChargingPointType)
                .ToListAsync();
        }

        public async Task<ChargingPoint> GetChargingPointByIdAsync(int id)
        {
            return await _context.ChargingPoints
                .Include(p => p.ChargingPointLocation)
                .Include(p => p.ChargingPointType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }       

        public async Task<IReadOnlyList<ChargingPointLocation>> GetChargingPointLocationsAsync()
        {
            return await _context.ChargingPointLocations.ToListAsync();
        }

        public async Task<IReadOnlyList<ChargingPointType>> GetChargingPointTypesAsync()
        {
            return await _context.ChargingPointTypes.ToListAsync();
        }
    }
}
