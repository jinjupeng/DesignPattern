﻿using System;

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
            if (requestInfo == null || StringUtils.isBlank(requestInfo.getApiName()))
            {
                return;
            }
            metricsStorage.saveRequestInfo(requestInfo);
        }
    }

    public class RequestInfo
    {
        private string apiName { get; set; }
        private double responseTime { get; set; }
        private long timestamp { get; set; }
    }
}
