using System;
using System.Collections;
using System.Collections.Generic;

namespace Storage.Generators
{
    public class EvenSequence : IEnumerator<int>
    {
        private int current;

        public int Current => this.current;

        object IEnumerator.Current => this.Current;

        public void SetCurrent(int id)
        {
            this.current = id;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            try
            {
                checked
                {
                    this.current += 2;
                }
            }
            catch (OverflowException)
            {
                Reset();
                return false;
            }
            
            return true;
        }

        public void Reset()
        {
            this.current = 0;
        }
    }
}
