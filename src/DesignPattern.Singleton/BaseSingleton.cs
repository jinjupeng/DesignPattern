using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Singleton
{
    /// <summary>
    /// 简单单例实现
    /// </summary>
    public class BaseSingleton
    {
        #region 基础单例

        /// <summary>
        /// 将默认构造函数设为私有，防止其它对象使用单例类的new运算符
        /// </summary>
        private BaseSingleton() { }

        /// <summary>
        /// 私有静态成员变量
        /// </summary>
        private static BaseSingleton _instance;

        /// <summary>
        /// 公有静态构造方法作为构造函数。该函数会“偷偷”调用私有构造函数来创建对象，
        /// 并将其保存在一个私有静态成员变量中。此后所有对于该函数的调用都将返回这一缓存对象。
        /// </summary>
        /// <returns></returns>
        public static BaseSingleton GetInstance()
        {
            if (_instance == null)
            {
                // 注意：如果程序需要支持多线程，必须在此位置放置线程锁
                _instance = new BaseSingleton();
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
            return param + "from " + _instance.GetHashCode();
        }

        #endregion
    }
}
