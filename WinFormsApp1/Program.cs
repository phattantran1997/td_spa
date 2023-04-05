using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using TD_SPA_Project.DBContext;
using TD_SPA_Project.Serivce.Implements;
using TD_SPA_Project.Serivce.Interfaces;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<FormMain>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                  .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.json",optional:false,reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) => {
                    services.AddTransient<IEmployeeRepository, EmployeeRepository>();
                    services.AddTransient<ICustomerRepository, CustomerRepository>();
                    services.AddTransient<FormMain>();
                    services.AddTransient<Form1>();
                    services.AddTransient<Form2>();

                    string connectionString = context.Configuration.GetConnectionString("MySQLConnectionString").ToString();
                    connectionString = "server=127.0.0.1;user=root;password=root;port=3306;database=TD_spa;";
                    services.AddDbContext<CommonContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

                })
              ;
        }
    }
}