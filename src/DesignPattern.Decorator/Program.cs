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
            /*
             * 当数据即将被写入磁盘前， 装饰对数据进行加密和压缩。 在原始类对改变毫无察觉的情况下， 将加密后的受保护数据写入文件。
             * 当数据刚从磁盘读出后， 同样通过装饰对数据进行解压和解密。 装饰和数据源类实现同一接口， 从而能在客户端代码中相互替换。
             */
            string salaryRecords = "Name,Salary\nJohn Smith,100000\nSteven Jobs,912000";
            DataSourceDecorator encoded = new CompressionDecorator(
                                             new EncryptionDecorator(
                                                 new FileDataSource("OutputDemo.txt")));

            //FileDataSource source = new FileDataSource("OutputDemo.txt");
            //CompressionDecorator compressSource = new CompressionDecorator(source);
            //EncryptionDecorator encryptSource = new EncryptionDecorator(source);
            //// 源变量中现在包含：Encryption > Compression > FileDataSource
            //// 已将压缩且加密的数据写入目标文件。
            //encryptSource.WriteData(salaryRecords);
            //Console.WriteLine(encryptSource.ReadData());


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

        }
    }
}
