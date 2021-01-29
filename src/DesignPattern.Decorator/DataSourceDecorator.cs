namespace DesignPattern.Decorator
{
    /// <summary>
    /// 抽象基础装饰
    /// </summary>
    public abstract class DataSourceDecorator : DataSource
    {
        private readonly DataSource wrappee;

        public DataSourceDecorator(DataSource source)
        {
            this.wrappee = source;
        }

        public override void WriteData(string data)
        {
            wrappee.WriteData(data);
        }

        public override string ReadData()
        {
            return wrappee.ReadData();
        }
    }
}
