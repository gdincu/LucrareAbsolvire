using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargingPointsController : ControllerBase
    {
        private readonly IChargingPointRepository _repo;

        public ChargingPointsController(IChargingPointRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChargingPoint>>> GetChargingPoints()
        {
            var chargingPoints = await _repo.GetChargingPointsAsync();
            return Ok(chargingPoints);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChargingPoint>> GetChargingPoint(int id)
        {
            var chargingPoint = await _repo.GetChargingPointByIdAsync(id);
            return Ok(chargingPoint);
        }

        [HttpPost]
        public string CreatePoint()
        {
            return "POST";
        }

        [HttpPut("{id}")]
        public string UpdatePoint()
        {
            return "PUT";
        }

        [HttpDelete("{id}")]
        public string DeletePoint(int id)
        {
            return "DELETE";
        }

        [HttpGet("locations")]
        public async Task<ActionResult<IReadOnlyList<ChargingPointLocation>>> GetChargingPointLocations()
        {
            return Ok(await _repo.GetChargingPointLocationsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ChargingPointType>>> GetChargingPointTypes()
        {
            return Ok(await _repo.GetChargingPointTypesAsync());
        }

    }
}