using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.DependencyInjection;
using Utils.Mapper.Interfaces;
using Utils.Reflection.Extensions;

namespace Utils.Mapper.Extensions
{
    public static class MapperServiceExtensionMethods
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            var callingAssembly = Assembly.GetCallingAssembly();

            services.AddAutoMapper(callingAssembly);

            Func<Type, bool> exprGoodInterfaces = (i) =>
                i.Name.Contains(typeof(IMapper<int, int>).Name) ||
                i.Name.Contains(typeof(IPartialMapper<int, int>).Name);

            var allAssemblies = new List<Assembly> { callingAssembly }
                .Union(
                    callingAssembly
                        .GetReferencedAssemblies()
                        .Select(assName => Assembly.Load(assName)))
                .ToList();


            var allInterfaces = allAssemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterfaces().Any(exprGoodInterfaces))
                .ToList();

            allInterfaces.ForEach(timpl =>
            {
                var allMappers = timpl.GetTypeInfo().GetInterfaces()
                                    .Where(exprGoodInterfaces)
                                    .ToList();

                allMappers.ForEach(m =>
                {
                    services.AddTransient(m, timpl);
                });
            });


            return services.AddTransient<IMapperService, MapperService>();
        }
        public static IServiceCollection AddAutoMapper(this IServiceCollection services, Assembly callingAssembly = null)
        {
            callingAssembly = callingAssembly ?? Assembly.GetCallingAssembly();

            var allAssemblies = new List<Assembly> { callingAssembly }
                .Union(callingAssembly
                        .GetReferencedAssemblies()
                        .Select(assName => Assembly.Load(assName)))
                .ToList();

            var mappers = allAssemblies
                .SelectMany(a => typeof(IAutoMapper)
                .GetDerivedTypes(a))
                .Where(t =>
                    !t.GetTypeInfo().IsInterface &&
                    !t.GetTypeInfo().IsAbstract)
                .ToList();

            var configMethodInterface = typeof(IAutoMapper).GetMethods().FirstOrDefault()?.Name;

            var config = new MapperConfiguration(cfg =>
            {
                mappers.ForEach(mapperClass =>
                {
                    var ctorParams = mapperClass
                        .GetConstructors()
                        .FirstOrDefault()?
                        .GetParameters()?
                        .Select(p => default(object))
                        .ToArray() ?? new object[] { };

                    mapperClass.GetMethod(configMethodInterface)?.Invoke(Activator.CreateInstance(mapperClass, ctorParams as object[]), new[] { cfg });
                });
            });

            var mapper = config.CreateMapper();

            return services.AddSingleton(mapper);
        }

        public static IEnumerable<U> Map<T, U>(this MapperService mapperService, IEnumerable<T> collection)
        {
            return collection.Select(p => mapperService.Map<T, U>(p));
        }

        public static IQueryable<U> Map<T, U>(this MapperService mapperService, IQueryable<T> collection)
        {
            return collection.ProjectTo<U>(mapperService.AutoMapper.ConfigurationProvider);
        }
    }
}