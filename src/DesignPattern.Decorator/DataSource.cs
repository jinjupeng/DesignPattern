namespace DesignPattern.Decorator
{
    public abstract class DataSource
    {
        public abstract void WriteData(string data);
        public abstract string ReadData();
    }
}
