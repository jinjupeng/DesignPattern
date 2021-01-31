namespace DesignPattern.FactoryMethod
{
    class Program
    {
        /*
         * 工厂方法模式
         * 工厂方法模式是一种创建型设计模式， 其在父类中提供一个创建对象的方法， 允许子类决定实例化对象的类型。
         */

        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
