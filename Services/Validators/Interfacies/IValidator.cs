using Services.Validators;

namespace Services.Validators.Interfacies
{
    public interface IValidator<T> where T : class
    {
        ValidationResult Validate(T entity);
    }
}