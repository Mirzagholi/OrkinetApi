using Microsoft.Extensions.DependencyInjection;

namespace Core.Ioc
{
    public static class AddCustomCorsExtensions
    {
        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        //.WithOrigins("http://localhost:1200") //Note:  The URL must be specified without a trailing slash (/).
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials());

                //.AllowAnyHeader()
                //        .AllowAnyOrigin()
                //        .AllowAnyMethod()
                //        //.SetIsOriginAllowed((host) => true)
                //        .AllowCredentials());

            });
        }
    }
}
