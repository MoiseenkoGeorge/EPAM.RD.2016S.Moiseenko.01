using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Generator
    {
        public static IEnumerator<int> GetEvenSequence()
        {
            int i = 0;
            while (true)
            {
                yield return i;
                checked
                {
                    i += 2;
                }
            }
        }
    }
}
