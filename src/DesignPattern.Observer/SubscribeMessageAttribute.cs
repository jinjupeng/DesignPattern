using System;

namespace DesignPattern.Observer
{
    /// <summary>
    /// 订阅消息特性
    /// 用于指定此方法已经订阅
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SubscribeMessageAttribute : Attribute
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="messageId"></param>
        public SubscribeMessageAttribute(string messageId)
        {
            MessageId = messageId;
        }

        /// <summary>
        /// 消息Id
        /// </summary>
        public string MessageId { get; set; }
    }
}
