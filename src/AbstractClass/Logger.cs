using System;
using System.IO;

namespace AbstractClass
{
    /// <summary>
    /// 抽象类
    /// 特性：
    /// 1、抽象类不允许被实例化，只能被继承。也就是说，你不能 new 一个抽象类的对象出来（Logger logger = new Logger(…); 会报编译错误）。
    /// 2、抽象类可以包含属性和方法。方法既可以包含代码实现（比如 Logger 中的 log() 方法），也可以不包含代码实现（比如 Logger 中的 doLog() 方法）。不包含代码实现的方法叫作抽象方法。
    /// 3、子类继承抽象类，必须实现抽象类中的所有抽象方法。对应到例子代码中就是，所有继承 Logger 抽象类的子类，都必须重写 doLog() 方法。
    /// 
    /// 接口特性：
    /// 1、接口不能包含属性（也就是成员变量）。
    /// 2、接口只能声明方法，方法不能包含代码实现。
    /// 3、类实现接口的时候，必须实现接口中声明的所有方法。
    /// </summary>
    public abstract class Logger
    {
        private string name;
        private bool enabled;
        private Level minPermittedLevel;

        public Logger(string name, bool enabled, Level minPermittedLevel)
        {
            this.name = name;
            this.enabled = enabled;
            this.minPermittedLevel = minPermittedLevel;
        }

        public void Log(Level level, string message)
        {
            bool loggable = enabled && ((int)minPermittedLevel <= (int)level);
            if (!loggable) return;
            DoLog(level, message);
        }

        protected abstract void DoLog(Level level, string message);
    }

    /// <summary>
    /// 抽象类的子类：输出日志到文件
    /// </summary>
    public class FileLogger : Logger
    {
        private FileStream fileWriter;

        public FileLogger(string name, bool enabled, Level minPermittedLevel, string filepath) : base(name, enabled, minPermittedLevel)
        {
            this.fileWriter = new FileStream(filepath, FileMode.Create);
        }

        protected override void DoLog(Level level, string mesage)
        {
            // 格式化level和message,输出到日志文件
            //开始写入
            byte[] data = System.Text.Encoding.Default.GetBytes(mesage);
            fileWriter.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fileWriter.Flush();
            fileWriter.Close();
        }
    }


    /// <summary>
    /// 抽象类的子类: 输出日志到消息中间件(比如kafka)
    /// </summary>
    public class MessageQueueLogger : Logger
    {
        /// <summary>
        /// 这是一个消息中间件
        /// </summary>
        private MessageQueueClient msgQueueClient;

        public MessageQueueLogger(string name, bool enabled,
          Level minPermittedLevel, MessageQueueClient msgQueueClient) : base(name, enabled, minPermittedLevel)
        {
            this.msgQueueClient = msgQueueClient;
        }

        protected override void DoLog(Level level, String mesage)
        {
            // 格式化level和message,输出到消息中间件
            msgQueueClient.send("");
        }
    }
}
