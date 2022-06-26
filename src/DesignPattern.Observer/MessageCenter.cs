using System;
using System.Threading.Tasks;

namespace DesignPattern.Observer
{
    public static class MessageCenter
    {
        //
        // 摘要:
        //     订阅消息
        //
        // 参数:
        //   messageId:
        //
        //   messageHandlers:
        public static void Subscribe<T>(string messageId, params Action<string, object>[] messageHandlers)
        {
            InternalMessageCenter.Instance.Subscribe<T>(messageId, messageHandlers);
        }

        //
        // 摘要:
        //     订阅消息
        //
        // 参数:
        //   messageId:
        //
        //   messageHandlers:
        public static void Subscribe<T>(string messageId, params Func<string, object, Task>[] messageHandlers)
        {
            InternalMessageCenter.Instance.Subscribe<T>(messageId, messageHandlers);
        }

        //
        // 摘要:
        //     发送消息
        //
        // 参数:
        //   messageId:
        //
        //   payload:
        //
        //   isSync:
        //     是否同步执行
        public static void Send(string messageId, object payload = null, bool isSync = false)
        {
            InternalMessageCenter.Instance.Send(messageId, payload, isSync);
        }

        //
        // 摘要:
        //     取消订阅
        //
        // 参数:
        //   messageId:
        public static void Unsubscribe(string messageId)
        {
            InternalMessageCenter.Instance.Unsubscribe(messageId);
        }
    }
}
