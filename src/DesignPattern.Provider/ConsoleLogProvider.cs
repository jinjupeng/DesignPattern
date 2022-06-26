using System;

namespace DesignPattern.Provider
{
    public class ConsoleLogProvider : LogProviderBase
    {
        public override void WriteLog(string msg)
        {
            Console.WriteLine($"这是将日志输出到控制台中，日志内容是：{msg}");
        }
    }
}
