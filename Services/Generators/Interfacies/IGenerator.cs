namespace Services.Generators.Interfacies
{
    public interface IGenerator<T>
    {
        T GetNewId();
    }
}