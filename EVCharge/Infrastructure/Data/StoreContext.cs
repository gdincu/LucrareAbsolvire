using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using System.Reflection;

namespace Infrastructure.Data
{
    public class StoreContext: DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ChargingPoint> ChargingPoints { get; set; }
        public DbSet<ChargingPointLocation> ChargingPointLocations { get; set; }
        public DbSet<ChargingPointType> ChargingPointTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
