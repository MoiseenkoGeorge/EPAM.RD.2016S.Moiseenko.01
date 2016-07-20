using System;
using System.Threading;

namespace Monitor
{
    // TODO: Use Monitor (not lock) to protect this structure.
    public class MyClass
    {
        private int _value;

        static object locker = new object();

        public int Counter
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public void Increase()
        {
            try
            {
                System.Threading.Monitor.Enter(locker);
                _value++;
            }
            finally
            {
                System.Threading.Monitor.Exit(locker);
            }
        }

        public void Decrease()
        {
            try
            {
                System.Threading.Monitor.Enter(locker);
                _value--;
            }
            finally
            {
                System.Threading.Monitor.Exit(locker);
            }

        }
    }
}
