using AutoMapper;
using TZ.Data.Models;
using TZ.WebApi.Dto;

namespace TZ.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RatingDTO, Rating>();
        }
    }
}
