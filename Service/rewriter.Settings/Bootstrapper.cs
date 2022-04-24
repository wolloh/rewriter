using Microsoft.Extensions.DependencyInjection;
using rewriter.Settings.Interface;
using rewriter.Settings.Settings;
using rewriter.Settings.Source;
namespace rewriter.Settings

{
    public static class Bootstrapper
    {
        public static void AddSettings(this IServiceCollection services)
        {
            services.AddSingleton<ISettingSource, SettingsSource>();
            services.AddSingleton<IApiSettings, ApiSettings>();
            services.AddSingleton<IGeneralSettings, GeneralSettings>();
            services.AddSingleton<IDbSettings, DbSettings>();
        }
    }
}