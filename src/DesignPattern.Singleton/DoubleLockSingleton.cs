using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Singleton
{
    /// <summary>
    /// Thread Safety By Double Lock
    /// </summary>
    public class DoubleLockSingleton
    {
        private static readonly object _SyncLock = new object();
        /// <summary>
        /// Private variable hold the instance.
        /// </summary>
        private static DoubleLockSingleton _Instance = null;

        /// <summary>
        /// Private constructor to prevent direct instance creation.
        /// </summary>
        private DoubleLockSingleton() { }

        /// <summary>
        /// The only entry point to get an instance of the class.
        /// </summary>
        public static DoubleLockSingleton Instance
        {
            get
            {

                if (_Instance == null)
                {
                    lock (_SyncLock)
                    {
                        if (_Instance == null) //Double check
                            _Instance = new DoubleLockSingleton();
                    }

                }
                return _Instance;
            }
        }

        /// <summary>
        /// Some Functionality.Hash code indicate same instance.
        /// </summary>
        /// <returns></returns>
        public string DoSomething(string param)
        {
            return param + "from " + _Instance.GetHashCode();
        }
    }
}
