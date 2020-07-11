using System;
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

        public async Task<ChargingPoint> GetChargingPointByIdAsync(int id)
        {
            return await _context.ChargingPoints.FindAsync(id);
        }

        public async Task<IReadOnlyList<ChargingPoint>> GetChargingPointsAsync()
        {
            return await _context.ChargingPoints.ToListAsync();
        }
    }
}
