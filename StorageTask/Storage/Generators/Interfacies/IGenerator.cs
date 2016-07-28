namespace Storage.Generators.Interfacies
{
    public interface IGenerator<T>
    {
        T Current { get; }

        T GetNewId();

        void Init(T id);
    }
}