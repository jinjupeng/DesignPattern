namespace PerformanceCounter
{
    public class MetricsCollector
    {
        private MetricsStorage metricsStorage;//基于接口而非实现编程

        //依赖注入
        public MetricsCollector(MetricsStorage metricsStorage)
        {
            this.metricsStorage = metricsStorage;
        }

        //用一个函数代替了最小原型中的两个函数
        public void recordRequest(RequestInfo requestInfo)
        {
            if (string.IsNullOrEmpty(requestInfo.apiName))
            {
                return;
            }
            metricsStorage.saveRequestInfo(requestInfo);
        }
    }

    public class RequestInfo
    {
        public RequestInfo(string apiName, double responseTime, long timestamp)
        {
            this.apiName = apiName;
            this.responseTime = responseTime;
            this.timestamp = timestamp;
        }
        public string apiName { get; set; }
        public double responseTime { get; set; }
        public long timestamp { get; set; }
    }
}
