using System.IO;

namespace DesignPattern.Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoConversionFacade converter = new VideoConversionFacade();
            FileStream mp4Video = converter.ConvertVideo("youtubevideo.ogg", "mp4");
            // ...
        }
    }
}
