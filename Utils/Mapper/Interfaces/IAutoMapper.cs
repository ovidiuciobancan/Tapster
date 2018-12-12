using AutoMapper;

namespace Utils.Mapper.Interfaces
{
    public interface IAutoMapper
    {
        void Config(IMapperConfigurationExpression config);
    }
}