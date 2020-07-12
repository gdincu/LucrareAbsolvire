using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<ChargingPoint, ChargingPointToReturnDto>()
                .ForMember(d => d.ChargingPointLocation, o => o.MapFrom(s => s.ChargingPointLocation.Name))
                .ForMember(d => d.ChargingPointType, o => o.MapFrom(s => s.ChargingPointType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ChargingPointUrlResolver>());
        }
    }
}