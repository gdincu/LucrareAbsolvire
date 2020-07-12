﻿using API.Controllers;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Controllers
{
    public class ChargingPointsController : BaseApiController
    {
        private readonly IGenericRepository<ChargingPoint> _chargingPointRepo;
        private readonly IGenericRepository<ChargingPointLocation> _chargingPointLocationRepo;
        private readonly IGenericRepository<ChargingPointType> _chargingPointTypeRepo;
        private readonly IMapper _mapper;

        public ChargingPointsController(IGenericRepository<ChargingPoint> chargingPointRepo,
            IGenericRepository<ChargingPointLocation> chargingPointLocationRepo,
            IGenericRepository<ChargingPointType> chargingPointTypeRepo, IMapper mapper)
        {
            _chargingPointRepo = chargingPointRepo;
            _chargingPointLocationRepo = chargingPointLocationRepo;
            _chargingPointTypeRepo = chargingPointTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChargingPointToReturnDto>>> GetChargingPoints()
        {
            var spec = new ChargingPointsWithTypesAndLocationsSpecification();
            var chargingPoints = await _chargingPointRepo.ListAsync(spec);
            //v1 -> return Ok(chargingPoints);

            /*v2 -> return Ok(chargingPoints.Select(chargingPoint => new ChargingPointToReturnDto {
                Id = chargingPoint.Id,
                Name = chargingPoint.Name,
                Description = chargingPoint.Description,
                Price = chargingPoint.Price,
                PictureUrl = chargingPoint.PictureUrl,
                ChargingPointType = chargingPoint.ChargingPointType.Name,
                ChargingPointLocation = chargingPoint.ChargingPointLocation.Name
            }).ToList());*/

            if (chargingPoints == null) return NotFound(new ApiResponse(404));
            //v3
            return Ok(_mapper.Map<IReadOnlyList<ChargingPoint>, IReadOnlyList<ChargingPointToReturnDto>>(chargingPoints));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ChargingPointToReturnDto>> GetChargingPoint(int id)
        {
            //var chargingPoint = await _chargingPointRepo.GetByIdAsync(id);
            var spec = new ChargingPointsWithTypesAndLocationsSpecification(id);
            var chargingPoint = await _chargingPointRepo.GetEntityWithSpec(spec);

            //v1 -> return Ok(chargingPoint);

            /*v2 -> return Ok(new ChargingPointToReturnDto
            {
                Id = chargingPoint.Id,
                Name = chargingPoint.Name,
                Description = chargingPoint.Description,
                Price = chargingPoint.Price,
                PictureUrl = chargingPoint.PictureUrl,
                ChargingPointType = chargingPoint.ChargingPointType.Name,
                ChargingPointLocation = chargingPoint.ChargingPointLocation.Name
            }); */

            if (chargingPoint == null) return NotFound(new ApiResponse(404));

            //v3
            return _mapper.Map<ChargingPoint, ChargingPointToReturnDto>(chargingPoint);
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
            return Ok(await _chargingPointLocationRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ChargingPointType>>> GetChargingPointTypes()
        {
            return Ok(await _chargingPointTypeRepo.ListAllAsync());
        }

    }
}