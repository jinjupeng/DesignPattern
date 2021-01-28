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
            string myStr = string.Empty;
            try
            {
                //FileStream fsRead = new FileStream(name, FileMode.Open);
                //int fsLen = (int)fsRead.Length;
                //byte[] heByte = new byte[fsLen];
                //int r = fsRead.Read(heByte, 0, heByte.Length);
                //myStr = Encoding.Default.GetString(heByte);
                //fsRead.Close();
                //fsRead.Dispose();
                StreamReader srReadFile = new StreamReader(name);
                myStr = srReadFile.ReadLine(); //读取每行数据
                                                            // 关闭读取流文件
                srReadFile.Close();
                srReadFile.Dispose();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return myStr;
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
