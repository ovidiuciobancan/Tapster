namespace Utils.Validation
{
    public interface IValidator<T>
    {
        ValidationResult ValidateModel(T instance);
    }
}