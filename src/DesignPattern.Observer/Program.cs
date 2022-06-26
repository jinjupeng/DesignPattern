using Microsoft.Extensions.DependencyInjection;

namespace DesignPattern.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            // 注册服务
            services.AddSimpleEventBus();

            MessageCenter.Send("create:oplog", "hello world");
            MessageCenter.Unsubscribe("create:oplog"); 
            MessageCenter.Send("create:oplog", "hello world");
        }
    }
}
