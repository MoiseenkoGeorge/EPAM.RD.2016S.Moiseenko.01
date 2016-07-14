namespace Services.Generators.Interfacies
{
    public interface IGenerator<T>
    {
        T GetNewId();

        void Init(T id);
    }
}