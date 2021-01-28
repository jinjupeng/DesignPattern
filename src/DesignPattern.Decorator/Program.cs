using System;

/// <summary>
/// 装饰模式
/// </summary>
namespace DesignPattern.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            string salaryRecords = "Name,Salary\nJohn Smith,100000\nSteven Jobs,912000";
            DataSourceDecorator encoded = new CompressionDecorator(
                                             new EncryptionDecorator(
                                                 new FileDataSource("out/OutputDemo.txt")));
            encoded.WriteData(salaryRecords);
            IDataSource plain = new FileDataSource("out/OutputDemo.txt");

            Console.WriteLine("- Input ----------------");
            Console.WriteLine();
            Console.WriteLine(salaryRecords);
            Console.WriteLine("- Encoded --------------");
            Console.WriteLine(plain.ReadData());
            Console.WriteLine("- Decoded --------------");
            Console.WriteLine(encoded.ReadData());
            Console.WriteLine("Hello World!");
        }
    }
}
