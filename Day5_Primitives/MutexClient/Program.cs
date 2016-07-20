﻿using System;
using System.Threading;

namespace MutexClient
{
    class Program
    {
        static void Main(string[] args)
        {
            bool createdNew = false;

            Mutex mutex = new Mutex(true, "MyMutex", out createdNew);

            // TODO: mutex = new Mutex(.., "MyMutex", out createdNew);

            Console.WriteLine("MutexClient. Mutex is new? " + createdNew + ". Waiting until mutex will be released.");

            mutex.WaitOne();
            // TODO: wait unit the mutex will be released

            Console.WriteLine("Press any key to release mutex.");
            Console.ReadKey();

            mutex.ReleaseMutex();
            // TODO: release mutex

            Console.WriteLine("Mutex is released. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
