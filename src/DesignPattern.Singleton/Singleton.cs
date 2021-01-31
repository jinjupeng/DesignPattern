
namespace DesignPattern.Singleton
{
    // The Singleton class defines the `GetInstance` method that serves as an
    // alternative to constructor and lets clients access the same instance of
    // this class over and over.
    public class Singleton
    {
        #region 基础单例

        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        /// <summary>
        /// 将默认构造函数设为私有，防止其它对象使用单例类的new运算符
        /// </summary>
        private Singleton() { }

        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        /// <summary>
        /// 静态成员变量
        /// </summary>
        private static Singleton _instance;

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        /// <summary>
        /// 新建一个静态构造方法作为构造函数。该函数会“偷偷”调用私有构造函数来创建对象，
        /// 并将其保存在一个静态成员变量中。此后所有对于该函数的调用都将返回这一缓存对象。
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                // 注意：如果程序需要支持多线程，必须在此位置放置线程锁
                _instance = new Singleton();
            }
            return _instance;
        }

        /// <summary>
        /// Finally, any singleton should define some business logic, which can be executed on its instance.
        /// Some Functionality.Hash code indicate same instance.
        /// </summary>
        /// <returns></returns>
        public string DoSomething(string param)
        {
            return param + "from " + _Instance.GetHashCode();
        }

        #endregion

    }

    /// <summary>
    ///  Thread Safety By Single Lock
    /// </summary>
    public class Singleton
    {
        private Singleton() { }

        private static Singleton _instance;

        #region 线程安全单例

        // We now have a lock object that will be used to synchronize threads
        // during first access to the Singleton.
        // 在创建首个单例对象时对线程进行同步
        private static readonly object _lock = new object();

        public static Singleton GetInstance(string value)
        {
            // This conditional is needed to prevent threads stumbling over the
            // lock once the instance is ready.
            if (_instance == null)
            {
                // Now, imagine that the program has just been launched. Since
                // there's no Singleton instance yet, multiple threads can
                // simultaneously pass the previous conditional and reach this
                // point almost at the same time. The first of them will acquire
                // lock and will proceed further, while the rest will wait here.
                lock (_lock)
                {
                    // The first thread to acquire the lock, reaches this
                    // conditional, goes inside and creates the Singleton
                    // instance. Once it leaves the lock block, a thread that
                    // might have been waiting for the lock release may then
                    // enter this section. But since the Singleton field is
                    // already initialized, the thread won't create a new
                    // object.
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }

        // We'll use this property to prove that our Singleton really works.
        public string Value { get; set; }

        /// <summary>
        /// Finally, any singleton should define some business logic, which can be executed on its instance.
        /// Some Functionality.Hash code indicate same instance.
        /// </summary>
        /// <returns></returns>
        public string DoSomething(string param)
        {
            return param + "from " + _Instance.GetHashCode();
        }

        #endregion
    }

    /// <summary>
    /// Thread Safety By Double Lock
    /// </summary>
    public class Singleton
    {
        private static readonly object _SyncLock = new object();
        /// <summary>
        /// Private variable hold the instance.
        /// </summary>
        private static Singleton _Instance = null;

        /// <summary>
        /// Private constructor to prevent direct instance creation.
        /// </summary>
        private Singleton() { }

        /// <summary>
        /// The only entry point to get an instance of the class.
        /// </summary>
        public static Singleton Instance
        {
            get
            {

                if (_Instance == null)
                {
                    lock (_SyncLock)
                    {
                        if (_Instance == null) //Double check
                            _Instance = new Singleton();
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

    /// <summary>
    /// Singleton lazy instantiation
    /// </summary>
    public class Singleton
    {

        /// <summary>
        /// Private constructor to prevent direct instance creation.
        /// </summary>
        private Singleton() { }

        /// <summary>
        /// The only entry point to get an instance of the class.
        /// </summary>
        public static Singleton Instance
        {
            get { return Nested.Instance; }
        }

        /// <summary>
        /// Some Functionality.
        /// </summary>
        /// <returns></returns>
        public string DoSomething(string param)
        {
            return param;
        }

        /// <summary>
        /// Nested class for lazy
        /// </summary>
        private class Nested
        {
            static Nested()
            { }
            internal static readonly Singleton Instance = new Singleton();
        }

    }
}
