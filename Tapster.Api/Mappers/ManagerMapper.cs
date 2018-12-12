using AutoMapper;
using Tapster.Api.Models.Managers;
using Tapster.DomainEntities.Entities;
using Utils.Mapper.Interfaces;

namespace Tapster.Api.Mappers
{
    public class ManagerMapper : IAutoMapper
    {
        public void Config(IMapperConfigurationExpression config)
        {
            config.CreateMap<Manager, ManagerVM>();
            config.CreateMap<ManagerVM, Manager>();
        }
    }
}
