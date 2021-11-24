using AutoMapper;
using Movies.Application.Commands;
using Movies.Application.Responses;
using Movies.Core.Entities;
using System.Linq;

namespace Movies.Application.Mappers
{
    public class MovieMapperProfile : Profile
    {
        public MovieMapperProfile()
        {
            //define how will be maping 
            CreateMap<Movie, MovieReponse>().ReverseMap();
            CreateMap<Movie, CreateMovieCommand>().ReverseMap();
            CreateMap<Movie, MovieDetailsResponse>().ForMember(md => md.Actors, m => m.MapFrom(am => am.ActorMovies.Select(ac => ac.Actor.Name)));
            CreateMap<MovieDetailsResponse, DeleteActorMovieCommand>().ReverseMap();
        }
    }
}