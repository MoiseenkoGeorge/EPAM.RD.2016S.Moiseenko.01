using System;
using System.Collections;
using System.Collections.Generic;
using MyClassLibrary;

namespace TaskConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable hash = new Hashtable();
            Helpers helpers = new Helpers();
            GetResult getResult = new GetResult();

            var a = new KeyValuePair<int, string>(0, "asd");

            hash.Add(helpers.GetHashCode(),helpers);
            hash.Add(helpers.GetHashCode(),getResult);
            hash.Add(a.GetHashCode(),a);

            KeyValuePair<int,string> result = (KeyValuePair<int,string>)hash.Remove(a.GetHashCode());

        }
    }
}
