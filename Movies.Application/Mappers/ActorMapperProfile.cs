using AutoMapper;
using Movies.Application.Commands;
using Movies.Application.Responses;
using Movies.Core.Entities;

namespace Movies.Application.Mappers
{
    public class ActorMapperProfile : Profile
    {
        public ActorMapperProfile()
        {
            //define how will be maping 
            CreateMap<Actor, ActorResponse>().ReverseMap();
            CreateMap<Actor, CreateActorCommand>().ReverseMap();
            CreateMap<Actor, UpdateActorCommand>().ReverseMap();
            CreateMap<Actor, ActorDetailsResponse>().ReverseMap();
        }
    }
}
