namespace Storage.Generators.Interfacies
{
    public interface IGenerator<T>
    {
        T GetNewId();

        void Init(T id);

        T Current { get; }
    }
}