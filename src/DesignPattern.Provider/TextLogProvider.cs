using System;

namespace DesignPattern.Provider
{
    public class TextLogProvider : LogProviderBase
    {
        public override void WriteLog(string msg)
        {
            Console.WriteLine($"这是将日志输出到文本文件中，日志内容是：{msg}");
        }
    }
}
