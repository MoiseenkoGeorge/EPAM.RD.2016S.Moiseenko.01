using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp
{
    class Program
    {
        //public class KeyValuepair
        static void Main(string[] args)
        {

            string s = "";

            StringBuilder sb = new StringBuilder("");

            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                s += "a";
            }
            sw.Stop();
            var a = sw.Elapsed;
            sw.Reset();

            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                sb.Append("a");
            }
            sw.Stop();
            var b = sw.Elapsed;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.ReadKey();
        }

    }
}
