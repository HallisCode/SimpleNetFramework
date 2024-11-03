using System.Collections.Generic;

namespace SimpleNetFramework.Core.Configuration
{
    /// <summary>
    /// Представляет собой объект конфигурации.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// Провайдеры которые достают информацию.
        /// </summary>
        IConfigurationProvider[] Providers { get; }

        /// <summary>
        /// Получает value по ключу из секции.
        /// </summary>
        /// <param name="key">Путь до ключа.</param>
        /// <returns>Value</returns>
        /// <code>IConfiguration["Section1:Section2:Key1"]</code>
        string this[string key] { get; set; }

        /// <summary>
        /// Получает value по ключу из секции.
        /// </summary>
        /// <param name="key">Путь до ключа.</param>
        /// <returns>Value</returns>
        /// <code>IConfiguration["Section1:Section2:Key1"]</code>
        string GetValue(string key);

        /// <summary>
        /// Получает секцию по ключу.
        /// </summary>
        /// <param name="section">Путь до секции.</param> 
        /// <returns>Секция с данными.</returns>
        /// <code>GetSection("Section1:Section2")</code>
        IConfiguration GetSection(string section);

        /// <summary>
        /// Получает вложенные ключи 1-го уровня.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetKeys();
        
    }
}