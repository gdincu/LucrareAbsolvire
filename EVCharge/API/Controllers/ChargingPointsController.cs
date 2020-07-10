using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChargingPointsController : ControllerBase
    {
        private readonly StoreContext _context;

        public ChargingPointsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChargingPoint>>> GetPoints()
        {
            var chargingPoints = await _context.ChargingPoints.ToListAsync();
            return Ok(chargingPoints);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChargingPoint>> GetPoint(int id)
        {
            return await _context.ChargingPoints.FindAsync(id);
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

    }
}