using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Interfaces.Services
{
    public interface IConfigurationAccessor
    {
        string GetConnectionString(string environment, string connectionName);
        string GetAppSettingValue(string environment, string key);
    }
}
