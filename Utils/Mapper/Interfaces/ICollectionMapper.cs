using System.Collections.Generic;

namespace Utils.Mapper.Interfaces
{
    public interface ICollectionMapper<T, U>
    {
        IEnumerable<U> Map(IEnumerable<T> source);
    }
}