using System;
using AutoMapper;
using Utils.Mapper.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace Utils.Mapper
{
    /// <summary>
    /// Mapper service used to aggregate all mappers
    /// </summary>
    public class MapperService : IMapperService
    {
        private readonly IServiceProvider Services;
        public IMapper AutoMapper { get; }
        public MapperService(IServiceProvider services, IMapper mapper)
        {
            Services = services;
            AutoMapper = mapper;
        }
        public U Map<T, U>(T source)
        {
            var converter = Services.GetService<IMapper<T, U>>();

            return converter.Map(source);
        }

        public U AutoMap<T, U>(T source)
        {
            return AutoMapper.Map<U>(source);
        }

        public void Map<T, U>(T source, U destination)
        {
            var converter = Services.GetService<IPartialMapper<T, U>>();

            converter.Map(source, destination);
        }

        public IEnumerable<U> ProjectTo<T, U>(IEnumerable<T> source)
        {
            return source.AsQueryable().ProjectTo<U>(AutoMapper.ConfigurationProvider);
        }
    }
}