using System;
using Services.Generators.Interfacies;

namespace Services.Generators
{
    public class Generator : IGenerator<int>
    {
        private readonly EvenSequence sequence = new EvenSequence();

        public int GetNewId()
        {
            int result = sequence.Current;
            sequence.MoveNext();
            return result;
        }
        /// <summary>
        /// Set start Generator number
        /// </summary>
        /// <param name="id"> start id. Must be even and positive </param>
        public void Init(int id)
        {
            if(id % 2 != 0 || id < 0)
                throw new InvalidOperationException();
            sequence.SetCurrent(id);
        }


    }
}