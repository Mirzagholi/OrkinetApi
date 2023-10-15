using Core.Common.Settings;
using Core.Ioc;
using Core.Service.Common;
using Core.Service.Hubs;
using DNTCommon.Web.Core;
using ElmahCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OfoghAds.ConfigLayer.IocConfig;
using Parbad.Builder;
using Parbad.Gateway.ParbadVirtual;
using Parbad.Gateway.Sepehr;

namespace Core.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // test
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SiteSettings>(options => Configuration.Bind(options));

            services.AddConfigServicesExtensions();

            services.AddDNTCommonWeb();

            services.AddParbad()
                .ConfigureGateways(gateways =>
                {
                    gateways
                        .AddSepehr()
                        .WithAccounts(accounts =>
                        {
                            accounts.AddInMemory(account =>
                            {
                                account.Name = "Sepehr"; // optional if there is only 1 account for this gateway
                                account.TerminalId = 98237175;
                            });
                        });
                })
                .ConfigureHttpContext(builder => builder.UseDefaultAspNetCore())
                .ConfigureStorage(builder => builder.AddStorage<ParbadStorage>(ServiceLifetime.Transient));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/api/error/index/500");
                app.UseStatusCodePagesWithReExecute("/api/error/index/{0}");
                app.UseCustomHsts();
                app.UseHttpsRedirection();
            }

            app.UseCustomSwagger();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseElmah();

           // app.UseCustomMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<InquiryHub>("/inquiry");
            });
        }
    }
}
