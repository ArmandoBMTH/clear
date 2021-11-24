using AutoMapper;
using System;

namespace Movies.Application.Mappers
{
    public class ActorMovieMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() => {
            var config = new MapperConfiguration(cfg => {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ActorMovieMapperProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        //Create a default ActorMovieMapper configuration 
        public static IMapper Mapper = Lazy.Value;
    }
}
