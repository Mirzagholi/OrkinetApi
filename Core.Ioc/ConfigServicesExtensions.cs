using Microsoft.Extensions.DependencyInjection;
using Core.Common.Settings;
using Microsoft.Extensions.Options;
using System;

namespace Core.Ioc
{
    public static class ConfigServicesExtensions
    {
        public static void AddConfigServicesExtensions(this IServiceCollection services)
        {
            var siteSettings = GetSiteSettings(services);
            services.AddCustomCors();
            services.AddCustomAntiforgery();
            services.AddCustomSwagger();
            services.AddCustomElmah(siteSettings);
            //db
            services.AddSignalR();
            services.AddCustomServices(siteSettings);
            services.AddCustomJwtBearer(siteSettings);
        }

        public static SiteSettings GetSiteSettings(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var siteSettingsOptions = provider.GetRequiredService<IOptionsSnapshot<SiteSettings>>();
            var siteSettings = siteSettingsOptions.Value;
            if (siteSettings == null) throw new ArgumentNullException(nameof(siteSettings));
            return siteSettings;
        }
    }
}
