﻿using System;
using System.Threading;

namespace DesignPattern.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 基础单例

            BaseSingleton s1 = BaseSingleton.GetInstance();
            BaseSingleton s2 = BaseSingleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instances.");
            }
            #endregion

            #region 线程安全单锁单例

            Console.WriteLine(
                "{0}\n{1}\n\n{2}\n",
                "If you see the same value, then singleton was reused (yay!)",
                "If you see different values, then 2 singletons were created (booo!!)",
                "RESULT:"
            );

            Thread process1 = new Thread(() =>
            {
                TestSingleton("FOO");
            });
            Thread process2 = new Thread(() =>
            {
                TestSingleton("BAR");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();

            #endregion

            #region 线程安全双锁单例

            Console.WriteLine(DoubleLockSingleton.Instance.DoSomething("Hay"));
            Console.WriteLine(DoubleLockSingleton.Instance.DoSomething("Halo"));
            Console.ReadLine();

            #endregion
        }

        public static void TestSingleton(string value)
        {
            SingleLockSingleton singleton = SingleLockSingleton.GetInstance(value);
            Console.WriteLine(singleton.Value);
        }
    }
}
