using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Core.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .ConfigureKestrel(options =>
                        {
                            options.AllowSynchronousIO = true;
                        })
                        .UseUrls("http://*:5800");//, "https://*:5801"
                });
       
    }
}
