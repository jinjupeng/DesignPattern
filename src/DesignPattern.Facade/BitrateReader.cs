using System;

namespace DesignPattern.Facade
{
    public class BitrateReader
    {
        public static VideoFile Read(VideoFile file, Codec codec)
        {
            Console.WriteLine("BitrateReader: reading file...");
            return file;
        }

        public static VideoFile Convert(VideoFile buffer, Codec codec)
        {
            Console.WriteLine("BitrateReader: writing file...");
            return buffer;
        }
    }
}
