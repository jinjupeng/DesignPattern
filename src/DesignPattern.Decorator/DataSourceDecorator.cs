using System;

namespace DesignPattern.Decorator
{
    /// <summary>
    /// 抽象基础装饰
    /// </summary>
    public abstract class DataSourceDecorator : IDataSource
    {
        private readonly IDataSource wrappee;

        public DataSourceDecorator(IDataSource source)
        {
            this.wrappee = source;
        }

        public void WriteData(string data)
        {
            wrappee.WriteData(data);
        }

        public string ReadData()
        {
            return wrappee.ReadData();
        }
    }
}
