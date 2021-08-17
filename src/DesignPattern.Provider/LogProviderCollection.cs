using System;
using System.Configuration.Provider;

namespace DesignPattern.Provider
{
    public sealed class LogProviderCollection : ProviderCollection
    {
        /// <summary>
        /// Gets the provider with the specified name.
        /// </summary>
        /// <param name="name">The name of the provider.</param>
        /// <returns></returns>
        public new LogProviderBase this[String name]
        {
            get { return base[name] as LogProviderBase; }
        }

        /// <summary>
        /// Adds a LogProvider to the collection.
        /// </summary>
        /// <param name="provider">The provider to be added</param>
        /// <exception cref="ArgumentNullException">provider is null</exception>
        /// <exception cref="NotSupportedException">provider is of wrong type</exception>
        public void Add(LogProviderBase provider)
        {
            // Validate arguments
            if (provider == null)
            {
                throw new ArgumentNullException("provider");
            }
            if (!provider.GetType().IsSubclassOf(typeof(LogProviderBase)))
            {
                throw new NotSupportedException("provider must inherit from BiscuitProvider");
            }

            // Add the provider to the base class
            base.Add((LogProviderBase)provider);
        }
    }
}
