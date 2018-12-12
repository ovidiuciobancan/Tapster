using System.Collections.Generic;
using AutoMapper;

namespace Utils.Mapper
{
    public interface IMapperService
    {
        IMapper AutoMapper { get; }

        U AutoMap<T, U>(T source);
        U Map<T, U>(T source);
        void Map<T, U>(T source, U destination);
        IEnumerable<U> ProjectTo<T, U>(IEnumerable<T> source);
    }
}