using System;
using System.Collections.Generic;
using System.Threading;

namespace PerformanceCounter
{

    public class ConsoleReporter
    {
        private MetricsStorage metricsStorage;
        private Timer timer;

        public ConsoleReporter(MetricsStorage metricsStorage)
        {
            this.metricsStorage = metricsStorage;
        }

        // 第4个代码逻辑：定时触发第1、2、3代码逻辑的执行；
        public void startRepeatedReport(long periodInSeconds, long durationInSeconds)
        {
            this.timer = new Timer(TimerCallback, null, durationInSeconds, periodInSeconds);
        }

        public void TimerCallback(object o)
        {
            // 第1个代码逻辑：根据给定的时间区间，从数据库中拉取数据；
            long durationInMillis = 1 * 1000;
            long endTimeInMillis = DateTime.Now.Millisecond;
            long startTimeInMillis = endTimeInMillis - durationInMillis;
            Dictionary<string, List<RequestInfo>> requestInfos =
                    metricsStorage.getRequestInfos(startTimeInMillis, endTimeInMillis);
            Dictionary<string, RequestStat> stats = new Dictionary<string, RequestStat>();
            foreach (var entry in requestInfos)
            {
                string apiName = entry.Key;
                List<RequestInfo> requestInfosPerApi = entry.Value;
                // 第2个代码逻辑：根据原始数据，计算得到统计数据；
                RequestStat requestStat = Aggregator.aggregate(requestInfosPerApi, durationInMillis);
                stats.Add(apiName, requestStat);
            }
            // 第3个代码逻辑：将统计数据显示到终端（命令行或邮件）；
            Console.WriteLine("Time Span: [" + startTimeInMillis + ", " + endTimeInMillis + "]");

        }
    }
}

