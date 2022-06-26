using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Singleton
{
    /// <summary>
    /// 懒加载实现单例模式
    /// </summary>
    public class LazySingleton
    {

        /// <summary>
        /// Private constructor to prevent direct instance creation.
        /// </summary>
        private LazySingleton() { }

        /// <summary>
        /// The only entry point to get an instance of the class.
        /// </summary>
        public static LazySingleton Instance
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
            internal static readonly LazySingleton Instance = new LazySingleton();
        }
    }
}
