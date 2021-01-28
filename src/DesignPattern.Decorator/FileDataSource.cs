using System.IO;

namespace DesignPattern.Decorator
{
    /// <summary>
    /// 简单数据读写器
    /// </summary>
    public class FileDataSource : IDataSource
    {
        private string name;

        public FileDataSource(string name)
        {
            this.name = name;
        }

        public string ReadData()
        {
            File file = new File(name);
            try (OutputStream fos = new FileOutputStream(file)) {
                fos.write(data.getBytes(), 0, data.length());
            } catch (IOException ex)
            {
                System.out.println(ex.getMessage());
            }
        }

        public void WriteData(string data)
        {
            char[] buffer = null;
            File file = new File(name);
            try (FileReader reader = new FileReader(file)) {
                buffer = new char[(int)file.length()];
                reader.read(buffer);
            } catch (IOException ex)
            {
                System.out.println(ex.getMessage());
            }
            return new string(buffer);
        }
    }
}
