using System;
using Storage.Generators.Interfacies;

namespace Storage.Generators
{
    public class Generator : IGenerator<int>
    {
        private readonly EvenSequence sequence = new EvenSequence();

        public int Current => this.sequence.Current;

        public int GetNewId()
        {
            int result = this.sequence.Current;
            this.sequence.MoveNext();
            return result;
        }

        /// <summary>
        /// Set start Generator number
        /// </summary>
        /// <param name="id"> start id. Must be even and positive </param>
        public void Init(int id)
        {
            if (id % 2 != 0 || id < 0)
                throw new InvalidOperationException();
            this.sequence.SetCurrent(id);
        }
    }
}