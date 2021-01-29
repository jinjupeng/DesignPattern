using System;

namespace DesignPattern.Facade
{
    public class CodecFactory
    {
        public static Codec Extract(VideoFile file)
        {
            string type = file.getCodecType();
            if (type.Equals("mp4"))
            {
                Console.WriteLine("CodecFactory: extracting mpeg audio...");
                return new MPEG4CompressionCodec();
            }
            else
            {
                Console.WriteLine("CodecFactory: extracting ogg audio...");
                return new OggCompressionCodec();
            }
        }
    }
}
