using HardkorowyKodsu.Proxy;
using HardkorowyKodsu.Services;
using HardkorowyKodsu.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestEase;

namespace HardkorowyKodsu
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            var ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<MainView>());
        }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddSingleton(context.Configuration);
                    services.AddTransient<MainView>();
                    services.AddTransient<IDbApiService, DbApiService>();
                    var endPoint = context.Configuration["ApiEndpoint"];
                    services.AddTransient(_ => RestClient.For<IDbApiProxy>(endPoint));


                });
        }
    }
}