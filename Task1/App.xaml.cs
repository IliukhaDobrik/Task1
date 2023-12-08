using System;
using System.Windows;
using DataLayer;
using DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Task1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<MyDbContext>(options =>
                    {
                        options.UseSqlServer(
                            "Server=USER-PC42\\MSSQLSERVER01;Database=Task1;Trusted_connection=True;TrustServerCertificate=True;");
                    });
                    services.AddSingleton<MainWindow>();
                }).Build();

            using (var serviceScope = _host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var masterWindow = services.GetRequiredService<MainWindow>();
                    masterWindow.Show();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _host.Services.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}