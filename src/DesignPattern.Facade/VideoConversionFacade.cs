using System;
using System.IO;

namespace DesignPattern.Facade
{
    public class VideoConversionFacade
    {
        /*
         * 门面模式为子系统提供一组统一的接口，定义一组高层接口让子系统更易用。
         * 门面模式提供统一入口 屏蔽使用者差异
         * 
         * 适配器是做接口转换，解决的是原接口和目标接口不匹配的问题。
         * 门面模式做接口整合，解决的是多接口调用带来的问题。
         */




        /// <summary>
        /// 对外提供了进行视频转换的简单接口
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public FileStream ConvertVideo(string fileName, string format)
        {
            Console.WriteLine("VideoConversionFacade: conversion started.");
            VideoFile file = new VideoFile(fileName);
            Codec sourceCodec = CodecFactory.Extract(file);
            Codec destinationCodec;
            if (format.Equals("mp4"))
            {
                destinationCodec = new OggCompressionCodec();
            }
            else
            {
                destinationCodec = new MPEG4CompressionCodec();
            }
            VideoFile buffer = BitrateReader.Read(file, sourceCodec);
            VideoFile intermediateResult = BitrateReader.Convert(buffer, destinationCodec);
            FileStream result = (new AudioMixer()).Fix(intermediateResult);
            Console.WriteLine("VideoConversionFacade: conversion completed.");
            return result;
        }
    }
}
