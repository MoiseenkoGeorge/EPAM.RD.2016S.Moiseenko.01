using System;
using System.Collections;
using System.Collections.Generic;

namespace Storage.Generators
{
    public class EvenSequence : IEnumerator<int>
    {
        private int current;

        public void SetCurrent(int id)
        {
            current = id;
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
                    current += 2;
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
            current = 0;
        }

        public int Current => current;

        object IEnumerator.Current => Current;
    }
}
