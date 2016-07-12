using Services.Interfacies;

namespace Services
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