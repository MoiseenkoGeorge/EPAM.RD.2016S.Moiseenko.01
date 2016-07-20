using System.Threading;

namespace Monitor
{
    // TODO: Use SpinLock to protect this structure.
    public class AnotherClass
    {
        private int _value;

        static SpinLock spinLock = new SpinLock();

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
            bool lockTaken = false;
            try
            {
                spinLock.Enter(ref lockTaken);
                _value++;
            }
            finally
            {
                if(lockTaken) spinLock.Exit(false);
            }
            
        }

        public void Decrease()
        {
            bool lockTaken = false;
            try
            {
                spinLock.Enter(ref lockTaken);
                _value--;
            }
            finally
            {
                if(lockTaken) spinLock.Exit(false);
            }
            
        }
    }
}
