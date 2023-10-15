using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Common.Settings;
using ElmahCore.Mvc;
using ElmahCore.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Core.Ioc
{
    public static class AddCustomElmahExtensions
    {
        public static void UseCustomElmah(this IApplicationBuilder app)
        {
            app.UseElmah();
        }

        public static void AddCustomElmah(this IServiceCollection services, SiteSettings siteSettings)
        {
            services.AddElmah<SqlErrorLog>(options =>
            {
                options.ConnectionString = siteSettings.SqlServer.ConnectionStrings.DefaultConnection;
                options.ApplicationName = "Orkinet";
                options.Path = "DevError";
            });
        }
    }
}
