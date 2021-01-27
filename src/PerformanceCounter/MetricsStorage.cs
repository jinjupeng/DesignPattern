using System;
using System.Collections.Generic;

namespace PerformanceCounter
{

    public interface MetricsStorage
    {
        void saveRequestInfo(RequestInfo requestInfo);

        List<RequestInfo> getRequestInfos(string apiName, long startTimeInMillis, long endTimeInMillis);

        Dictionary<string, List<RequestInfo>> getRequestInfos(long startTimeInMillis, long endTimeInMillis);
    }

    // 一次拉取太多数据，容易造成OOM（Out Of Memory）
    public class RedisMetricsStorage : MetricsStorage
    {
        public List<RequestInfo> getRequestInfos(string apiName, long startTimeInMillis, long endTimeInMillis)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, List<RequestInfo>> getRequestInfos(long startTimeInMillis, long endTimeInMillis)
        {
            // 模拟返回数据。
            Dictionary<string, List<RequestInfo>> map = new Dictionary<string, List<RequestInfo>>();
            map.Add("register", new List<RequestInfo>{
                new RequestInfo("register", 123, 10234),
                new RequestInfo("register", 223, 12223),
                new RequestInfo("register", 323, 12334)
            });
            map.Add("login", new List<RequestInfo>{
                new RequestInfo("login", 23, 12434),
                new RequestInfo("login", 1223, 14234)
            });

            return map;
        }

        public void saveRequestInfo(RequestInfo requestInfo)
        {
            // 保存到redis中
        }
    }
}
