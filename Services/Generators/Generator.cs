using Services.Generators.Interfacies;

namespace Services.Generators
{
    public class Generator : IGenerator<int>
    {
        private readonly Sequence sequence = new Sequence();

        public int GetNewId()
        {
            int result = sequence.Current;
            sequence.MoveNext();
            return result;
        } 
    }
}