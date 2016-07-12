using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Sequence : IEnumerator<int>
    {
        private int current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            checked
            {
                current += 2;
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
