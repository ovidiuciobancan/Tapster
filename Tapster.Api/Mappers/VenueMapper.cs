using AutoMapper;
using Tapster.Api.Models.Venues;
using Tapster.DomainEntities.Entities;
using Utils.Mapper.Interfaces;

namespace Tapster.Api.Mappers
{
    public class VenueMapper : IAutoMapper
    {
        public void Config(IMapperConfigurationExpression config)
        {
            config.CreateMap<Venue, VenueVM>();
            config.CreateMap<VenueVM, Venue>();
            config.CreateMap<Venue, CreateVenueVM>();
            config.CreateMap<CreateVenueVM, Venue>();
        }
    }
}
