using System;
using System.Text;

namespace DesignPattern.Decorator
{
    /// <summary>
    /// 加密装饰
    /// </summary>
    public class EncryptionDecorator : DataSourceDecorator
    {

        public EncryptionDecorator(DataSource source) : base(source)
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

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string Encode(string data)
        {
            byte[] result = Encoding.Default.GetBytes(data);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] += 1;
            }
            
            return Convert.ToBase64String(result);
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string Decode(string data)
        {
            byte[] result = Convert.FromBase64String(data);
            for (int i = 0; i < result.Length; i++)
            {
                result[i] -= 1;
            }
            return Encoding.Default.GetString(result);
        }
    }
}
