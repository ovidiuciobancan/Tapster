using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;

using Utils.Reflection.Extensions;

namespace Utils.EntityFrameworkCore.Extensions
{
    public static class EFCoreExtensions
    {
        public static IWebHost MigrateDb<T>(this IWebHost host, Assembly assembly = null)
            where T : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<T>();
                context.Database.Migrate();
            }
            return host;
        }
        public static IWebHost SeedData<TDbContext>(this IWebHost host, Assembly assembly = null)
            where TDbContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<TDbContext>();
                var seeders = typeof(ISeeder<TDbContext>)
                    .GetDerivedTypes(assembly ?? Assembly.GetCallingAssembly())
                    .Where(t => t.GetTypeInfo().IsAbstract == false)
                    .Select(t => (ISeeder<TDbContext>)scope.ServiceProvider.GetService(t))
                    .ToList();

                seeders.ForEach(i => i.Seed(context));
            }

            return host;
        }

        public static IServiceCollection AddSeeding<TDbContext>(this IServiceCollection services, Assembly assembly = null)
            where TDbContext : DbContext
        {
            var types = typeof(ISeeder<TDbContext>)
                .GetDerivedTypes(assembly ?? Assembly.GetCallingAssembly())
                .Where(t => t.GetTypeInfo().IsAbstract == false)
                .ToList();
                
            types.ForEach(t => services.AddScoped(t));

            return services;
        }

        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, IEntityTypeMapping<TEntity> configuration)
            where TEntity : class
        {
            configuration.Map(modelBuilder.Entity<TEntity>());
        }
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder)
            where TEntity : class
        {
            var configurations = typeof(IEntityTypeMapping<TEntity>)
                .GetDerivedTypes(Assembly.GetCallingAssembly())
                .Select(type => (IEntityTypeMapping<TEntity>)Activator.CreateInstance(type));

            foreach (var config in configurations)
            {
                config.Map(modelBuilder.Entity<TEntity>());
            }
        }
        public static IEnumerable<IProperty> PrimaryKey<T>(this DbContext context)
            where T : class, new()
        {
            return context.Model
                .FindEntityType(typeof(T))
                .FindPrimaryKey()
                .Properties;
        }
        public static T Stub<T>(this IEnumerable<IProperty> properties, params object[] values)
            where T : class, new()
        {
            if (properties == null || values == null || properties.Count() != values.Count())
            {
                throw new ArgumentException("Paramters must be not null and have save length");
            }

            var result = new T();

            properties
                .Select(p => p.Name)
                .Select(p => typeof(T).GetProperty(p))
                .Zip(values, (prop, value) => new
                {
                    Property = prop,
                    Value = value
                })
                .ToList()
                .ForEach(item => item.Property.SetValue(result, item.Value));

            return result;
        }
    }

    #region Interfaces
    public interface ISeeder<TDbContext>
        where TDbContext : DbContext
    {
        void Seed(TDbContext context);
    }
    public interface IEntityTypeMapping<TEntity>
          where TEntity : class
    {
        void Map(EntityTypeBuilder<TEntity> entity);
    }
    #endregion

}