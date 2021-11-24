using AutoMapper;
using System;

namespace Movies.Application.Mappers
{
    public class ActorMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() => {
            var config = new MapperConfiguration(cfg => {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ActorMapperProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        //Create a default ActorMapper configuration 
        public static IMapper Mapper = Lazy.Value;
    }
}
