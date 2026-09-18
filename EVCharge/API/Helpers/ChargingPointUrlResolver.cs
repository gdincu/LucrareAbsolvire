using System.Linq;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ChargingPointUrlResolver : IValueResolver<ChargingPoint, ChargingPointToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public ChargingPointUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(ChargingPoint source, ChargingPointToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return _config["ApiUrl"] + source.PictureUrl;

            return null;
        }
    }
}