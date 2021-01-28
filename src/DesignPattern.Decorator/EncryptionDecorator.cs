using System;

namespace DesignPattern.Decorator
{
    /// <summary>
    /// 加密装饰
    /// </summary>
    public class EncryptionDecorator : DataSourceDecorator
    {

        public EncryptionDecorator(IDataSource source) : base(source)
        {
        }

        public override void WriteData(string data)
        {
            base.WriteData(Encode(data));
        }

        public override string ReadData()
        {
            return Decode(base.ReadData());
        }

        private string Encode(string data)
        {
            byte[] result = data.getBytes();
            for (int i = 0; i < result.length; i++)
            {
                result[i] += (byte)1;
            }
            return Base64.getEncoder().encodeToString(result);
        }

        private string Decode(string data)
        {
            byte[] result = Base64.getDecoder().decode(data);
            for (int i = 0; i < result.length; i++)
            {
                result[i] -= (byte)1;
            }
            return new string(result);
        }
    }
}
