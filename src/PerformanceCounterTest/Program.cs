using PerformanceCounter;
using System;
using System.Threading;

namespace PerformanceCounterTest
{

    public class Program
    {
        public static void Main(string[] args)
        {
            MetricsStorage storage = new RedisMetricsStorage();
            ConsoleReporter consoleReporter = new ConsoleReporter(storage);
            consoleReporter.startRepeatedReport(60, 60);


            MetricsCollector collector = new MetricsCollector(storage);
            collector.recordRequest(new RequestInfo("register", 123, 10234));
            collector.recordRequest(new RequestInfo("register", 223, 11234));
            collector.recordRequest(new RequestInfo("register", 323, 12334));
            collector.recordRequest(new RequestInfo("login", 23, 12434));
            collector.recordRequest(new RequestInfo("login", 1223, 14234));

            try
            {
                Thread.Sleep(100000);
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
    }
}
