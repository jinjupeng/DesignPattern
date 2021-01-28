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
                                                 new FileDataSource("OutputDemo.txt")));
            encoded.WriteData(salaryRecords);
            DataSource plain = new FileDataSource("OutputDemo.txt");

            Console.WriteLine("- Input ----------------");
            Console.WriteLine();
            Console.WriteLine(salaryRecords);
            Console.WriteLine("- Encoded --------------");
            Console.WriteLine(plain.ReadData());
            Console.WriteLine("- Decoded --------------");
            Console.WriteLine(encoded.ReadData());
            Console.WriteLine("Hello World!");

            /*
                - Input ----------------
                Name,Salary
                John Smith,100000
                Steven Jobs,912000
                - Encoded --------------
                Zkt7e1Q5eU8yUm1Qe0ZsdHJ2VXp6dDBKVnhrUHtUe0sxRUYxQkJIdjVLTVZ0dVI5Q2IwOXFISmVUMU5rcENCQmdxRlByaD4+
                - Decoded --------------
                Name,Salary
                John Smith,100000
                Steven Jobs,912000
             */
        }
    }
}
