using System;
using System.IO;

namespace DesignPattern.Facade
{
    public class AudioMixer
    {
        /// <summary>
        /// 添加音频
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public FileStream Fix(VideoFile result)
        {
            Console.WriteLine("AudioMixer: fixing audio...");
            return File.Create("tmp");
        }
    }
}
