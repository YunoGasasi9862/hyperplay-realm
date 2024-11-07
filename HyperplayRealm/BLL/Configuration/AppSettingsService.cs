using BLL.Configuration.Model;
using BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Configuration
{
    //Im creating AppSetting Service, but you can directly call it in program.cs
    public class AppSettingsService : IAppSettings
    {
        public IConfigurationSection AppSettingsSection { get; set; }
        public AppSettingsService(IConfiguration configuration)
        {
            AppSettingsSection = configuration.GetSection(nameof(AppSettings));
        }

        public AppSettings? GetAppSettings()
        {
            return AppSettingsSection.Get<AppSettings>();
        }
    }
}
