using System;
using System.IO;
using System.Text;

namespace DesignPattern.Decorator
{
    /// <summary>
    /// 简单数据读写器
    /// </summary>
    public class FileDataSource : DataSource
    {
        private string name;

        public FileDataSource(string name)
        {
            this.name = name;
        }

        public override string ReadData()
        {
            string txtStr = string.Empty;
            try
            {
                StreamReader srReadFile = new StreamReader(name);
                // 一次读取一行数据，如果需要读取全部数据，则需要while循环
                txtStr = srReadFile.ReadLine();
                // 关闭读取流文件
                srReadFile.Close();
                srReadFile.Dispose();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return txtStr;
        }

        public override void WriteData(string data)
        {
            try
            {
                if (!File.Exists(name))
                {
                    FileStream f = File.Create(name);
                    f.Close();
                    f.Dispose();
                }
                StreamWriter f2 = new StreamWriter(name, true, Encoding.UTF8);
                f2.WriteLine(data);
                f2.Close();
                f2.Dispose();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
