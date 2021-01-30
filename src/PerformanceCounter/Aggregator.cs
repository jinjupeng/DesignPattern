using System;
using System.Collections.Generic;

namespace PerformanceCounter
{

    public class Aggregator
    {
        public static RequestStat aggregate(List<RequestInfo> requestInfos, long durationInMillis)
        {
            double maxRespTime = Double.MinValue;
            double minRespTime = Double.MaxValue;
            double avgRespTime = -1;
            double p999RespTime = -1;
            double p99RespTime = -1;
            double sumRespTime = 0;
            long count = 0;
            foreach (RequestInfo requestInfo in requestInfos)
            {
                ++count;
                double respTime = requestInfo.responseTime;
                if (maxRespTime < respTime)
                {
                    maxRespTime = respTime;
                }
                if (minRespTime > respTime)
                {
                    minRespTime = respTime;
                }
                sumRespTime += respTime;
            }
            if (count != 0)
            {
                avgRespTime = sumRespTime / count;
            }
            long tps = (long)(count / durationInMillis * 1000);

            // 在Lambda表达式中使用Comparison<T>进行排序
            requestInfos.Sort((x, y) => x.responseTime.CompareTo(y.responseTime));
            // 等价于
            //requestInfos.Sort(delegate (RequestInfo o1, RequestInfo o2)
            //{
            //    return o1.responseTime.CompareTo(o2.responseTime);
            //});

            int idx999 = (int)(count * 0.999);
            int idx99 = (int)(count * 0.99);
            if (count != 0)
            {
                //  请求时间List 按照请求时间排序后的（总请求次数*0.999）的index 对应的 List(index) 的时间值
                p999RespTime = requestInfos[idx999].responseTime;
                p99RespTime = requestInfos[idx99].responseTime;
            }
            RequestStat requestStat = new RequestStat
            {
                maxResponseTime = maxRespTime,
                minResponseTime = minRespTime,
                avgResponseTime = avgRespTime,
                p999ResponseTime = p999RespTime,
                p99ResponseTime = p99RespTime,
                count = count,
                tps = tps
            };
            return requestStat;
        }

    }

    public class RequestStat
    {
        public double maxResponseTime { get; set; }
        public double minResponseTime { get; set; }
        public double avgResponseTime { get; set; }
        public double p999ResponseTime { get; set; }
        public double p99ResponseTime { get; set; }
        public long count { get; set; }
        public long tps { get; set; }
    }
}

