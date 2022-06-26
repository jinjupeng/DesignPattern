using System;

namespace DesignPattern.Observer
{
    public class LogSubscribeHandler : ISubscribeHandler
    {
        [SubscribeMessage("update:logininfo")]
        public void UpdateUserLoginInfo(string eventId, object payload)
        {
        }

        /// <summary>
        ///访问日志
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="payload"></param>
        [SubscribeMessage("create:oplog")]
        public void CreateOpLog(string eventId, object payload)
        {
            Console.WriteLine(payload.ToString());
        }
    }
}
