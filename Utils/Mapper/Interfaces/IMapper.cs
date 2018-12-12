namespace Utils.Mapper.Interfaces
{
    public interface IMapper<T, U>
    {
        U Map(T source);
    }
}