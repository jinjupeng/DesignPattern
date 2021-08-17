using System.Configuration.Provider;

namespace DesignPattern.Provider
{
    public abstract class LogProviderBase : ProviderBase
    {
        public abstract void WriteLog(string msg);
    }
}
