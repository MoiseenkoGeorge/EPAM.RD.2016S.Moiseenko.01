namespace Services.Interfacies
{
    public interface IGenerator<T>
    {
        T GetNewId();
    }
}