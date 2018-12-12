namespace Utils.Mapper.Interfaces
{
    public interface IPartialMapper<T, U>
    {
        void Map(T source, U destination);
    }
}