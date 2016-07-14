namespace Storage.Validators.Interfacies
{
    public interface IValidator<T> where T : class
    {
        ValidationResult Validate(T entity);
    }
}