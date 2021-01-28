using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace DesignPattern.Decorator
{
    /// <summary>
    /// 压缩装饰
    /// </summary>
    public class CompressionDecorator : DataSourceDecorator
    {
        private int compLevel = 6;

        public CompressionDecorator(DataSource source) : base(source)
        {

        }

        public int GetCompressionLevel()
        {
            return compLevel;
        }

        public void SetCompressionLevel(int value)
        {
            compLevel = value;
        }

        public override void WriteData(string data)
        {
            var compressBeforeByte = Encoding.Default.GetBytes(data);
            var compressAfterByte = Compress(compressBeforeByte);
            string compressString = Convert.ToBase64String(compressAfterByte);
            base.WriteData(compressString);
        }

        public override string ReadData()
        {
            var compressBeforeByte = Convert.FromBase64String(base.ReadData());
            var compressAfterByte = Decompress(compressBeforeByte);
            string compressString = Encoding.Default.GetString(compressAfterByte);
            return compressString;
        }

        /// <summary>
        /// Compress
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static byte[] Compress(byte[] data)
        {
            try
            {
                var ms = new MemoryStream();
                var zip = new GZipStream(ms, CompressionMode.Compress, true);
                zip.Write(data, 0, data.Length);
                zip.Close();
                var buffer = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, buffer.Length);
                ms.Close();
                return buffer;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Decompress
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static byte[] Decompress(byte[] data)
        {
            try
            {
                var ms = new MemoryStream(data);
                var zip = new GZipStream(ms, CompressionMode.Decompress, true);
                var msreader = new MemoryStream();
                var buffer = new byte[0x1000];
                while (true)
                {
                    var reader = zip.Read(buffer, 0, buffer.Length);
                    if (reader <= 0)
                    {
                        break;
                    }
                    msreader.Write(buffer, 0, reader);
                }
                zip.Close();
                ms.Close();
                msreader.Position = 0;
                buffer = msreader.ToArray();
                msreader.Close();
                return buffer;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
