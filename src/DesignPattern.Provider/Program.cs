using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Provider
{
    class Program
    {
        static void Main(string[] args)
        {
            var defaultProviderName = "console";
            var consoleProvider = new ConsoleLogProvider();
            consoleProvider.Initialize(defaultProviderName, null);
            LogProviderManager.Providers.Add(consoleProvider);
            LogProviderManager.DefaultProvider = defaultProviderName;
            var provider = LogProviderManager.Provider;
            provider.WriteLog("测试");
        }
    }
}
