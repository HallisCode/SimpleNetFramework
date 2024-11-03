using System.Collections.Generic;

namespace SimpleNetFramework.Core.Configuration
{
    /// <summary>
    /// Представляет провайдер, который получает настройки конфигурации.
    /// </summary>
    public interface IConfigurationProvider
    {
        IDictionary<string, string> Data { get; }

        /// <summary>
        /// Загружает данные.
        /// </summary>
        void Load();
    }
}