using AutoMapper;
using Movies.Application.Commands;
using Movies.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Application.Mappers
{
    public class ActorMovieMapperProfile : Profile
    {
        public ActorMovieMapperProfile()
        {
            //define how will be maping 
            CreateMap<ActorMovie, CreateActorMovieCommand>().ReverseMap();
        }
    }
}
