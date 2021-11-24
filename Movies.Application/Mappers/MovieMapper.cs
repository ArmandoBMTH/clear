using AutoMapper;
using System;

namespace Movies.Application.Mappers
{
    public class MovieMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() => {
            var config = new MapperConfiguration(cfg => {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MovieMapperProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        //Create a default MovieMapper configuration
        public static IMapper Mapper = Lazy.Value;
    }
}
