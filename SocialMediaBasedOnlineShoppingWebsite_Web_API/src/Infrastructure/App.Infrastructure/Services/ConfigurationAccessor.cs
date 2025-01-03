using App.Application.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace App.Infrastructure.Services
{
    public class ConfigurationAccessor : IConfigurationAccessor
    {
        private readonly string _basePath;
        private readonly IHostingEnvironment _hostEnvironment;

        public ConfigurationAccessor(IHostingEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _basePath = _hostEnvironment.ContentRootPath;
        }

        public string GetConnectionString(string environment, string connectionName)
        {
            string environmentSpecificFile = $"appsettings.{environment}.json";
            string filePath = Path.Combine(_basePath, environmentSpecificFile);

            if (File.Exists(filePath))
            {
                var configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(_basePath);
                configurationManager.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                configurationManager.AddJsonFile(environmentSpecificFile, optional: true, reloadOnChange: true);

                return configurationManager.GetConnectionString(connectionName);
            }
            else
            {
                throw new FileNotFoundException($"Configuration file {environmentSpecificFile} not found at {filePath}");
            }
        }

        public string GetAppSettingValue(string environment, string key)
        {
            string environmentSpecificFile = $"appsettings.{environment}.json";
            string filePath = Path.Combine(_basePath, environmentSpecificFile);

            if (File.Exists(filePath))
            {
                var configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(_basePath);
                configurationManager.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                configurationManager.AddJsonFile(environmentSpecificFile, optional: true, reloadOnChange: true);

                return configurationManager[key];
            }
            else
            {
                throw new FileNotFoundException($"Configuration file {environmentSpecificFile} not found at {filePath}");
            }
        }
    }
}
