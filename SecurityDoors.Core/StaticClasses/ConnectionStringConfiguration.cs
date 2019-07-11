using Microsoft.Extensions.Configuration;
using SecurityDoors.Core.Constants;
using System.IO;

namespace SecurityDoors.Core.StaticClasses
{
    /// <summary>
    /// Вспомогательный класс получения ConnectionString.
    /// </summary>
    public static class ConnectionStringConfiguration
    {
        /// <summary>
        /// Получить строку подключения.
        /// </summary>
        /// <returns>Строка подключения.</returns>
        public static string GetConnectionString()
        {
            var connectionString = string.Empty;

            if (File.Exists("appsettings.json"))
            {
                var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                var configuration = builder.Build();

                connectionString = configuration.GetConnectionString("DefaultConnection");
            }
            else
            {
                connectionString = AppConstants.CONNECTION_STRING;
            }

            return connectionString;
        }
    }
}
