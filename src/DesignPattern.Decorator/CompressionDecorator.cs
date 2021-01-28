using System;
using System.Buffers.Text;

namespace DesignPattern.Decorator
{
    /// <summary>
    /// 压缩装饰
    /// </summary>
    public class CompressionDecorator : DataSourceDecorator
    {
        private int compLevel = 6;

        public CompressionDecorator(IDataSource source) : base(source)
        {

        }

        public int getCompressionLevel()
        {
            return compLevel;
        }

        public void setCompressionLevel(int value)
        {
            compLevel = value;
        }

        public override void WriteData(String data)
        {
            base.WriteData(Compress(data));
        }

        public override string ReadData()
        {
            return decompress(base.ReadData());
        }

        private string Compress(string stringData)
        {
            byte[] data = stringData.getBytes();
            try
            {
                ByteArrayOutputStream bout = new ByteArrayOutputStream(512);
                DeflaterOutputStream dos = new DeflaterOutputStream(bout, new Deflater(compLevel));
                dos.write(data);
                dos.close();
                bout.close();
                return Base64.getEncoder().encodeToString(bout.toByteArray());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private string decompress(string stringData)
        {
            byte[] data = Base64.getDecoder().decode(stringData);
            try
            {
                InputStream in = new ByteArrayInputStream(data);
                InflaterInputStream iin = new InflaterInputStream(in);
                ByteArrayOutputStream bout = new ByteArrayOutputStream(512);
                int b;
                while ((b = iin.read()) != -1)
                {
                    bout.write(b);
                }
            in.close();
                iin.close();
                bout.close();
                return new string(bout.toByteArray());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
