using System.Linq;
using System.Collections.Generic;
using AutoMapper;

using Utils.Mapper;
using Utils.Mapper.Interfaces;
using Tapster.DomainEntities.Entities;
using Tapster.Api.Models.Categories;
using Tapster.Api.Models.Products;

namespace Tapster.Api.Mappers
{
    public class MenuCategoryMapper : IAutoMapper, ICollectionMapper<Category, CategoryVM> 
    {
        private readonly IMapperService mapper;

        public MenuCategoryMapper(IMapperService mapper)
        {
            this.mapper = mapper;
        }

        public void Config(IMapperConfigurationExpression config)
        {
            config.CreateMap<Category, CategoryVM>();
            config.CreateMap<CategoryVM, Category>();
            config.CreateMap<Product, ProductVM>();
            config.CreateMap<ProductVM, Product>();
        }

        public IEnumerable<CategoryVM> Map(IEnumerable<Category> source)
        {
            var flatList = source.ToList();

            var result = flatList
                .Where(p => p.ParentCategoryId == null)
                .Select(p => mapper.AutoMap<Category, CategoryVM>(p))
                .ToList();

            while(flatList.Any())
            {
                var itemToRemove = result.Select(p => p.Id);
                flatList.RemoveAll(p => itemToRemove.Contains(p.Id));
            }

            return null;
        }

        //private CategoryVM Map(CategoryVM category, IEnumerable<Category> flatList)
        //{
        //    category.SubCategories = 

        //    return 
        //}
    }
}
