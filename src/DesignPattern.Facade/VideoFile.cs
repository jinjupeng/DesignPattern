namespace DesignPattern.Facade
{
    public class VideoFile
    {
        private string name;
        private string codecType;

        public VideoFile(string name)
        {
            this.name = name;
            this.codecType = name.Substring(name.IndexOf(".") + 1);
        }

        public string getCodecType()
        {
            return codecType;
        }

        public string getName()
        {
            return name;
        }
    }
}
