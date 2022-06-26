using System;

namespace DesignPattern.Provider
{
    public class LogProviderManager
    {
        private static LogProviderCollection _providers;

        /// <summary>
        /// Initializes the <see cref="LogProviderManager"/> class.
        /// </summary>
        static LogProviderManager()
        {
            _providers = new LogProviderCollection();
        }

        /// <summary>
        /// Gets or sets the default provider
        /// </summary>
        public static String DefaultProvider { get; set; }

        /// <summary>
        /// Gets the default provider.
        /// </summary>
        /// <value>
        /// The default sweet provider.
        /// </value>
        public static LogProviderBase Provider
        {
            get { return Providers[DefaultProvider]; }
        }

        /// <summary>
        /// Gets the provider collection.
        /// </summary>
        /// <value>
        /// The collection of providers.
        /// </value>
        public static LogProviderCollection Providers
        {
            get { return _providers; }
        }
    }
}
