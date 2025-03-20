using AutoMapper;
using Daily.Planner.with.God.Application.Dtos;

namespace Daily.Planner.with.God.Application.Mapper
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CardUpdateDto, Card>();
        }
    }
}
