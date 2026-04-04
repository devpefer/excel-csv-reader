using Avalonia;
using ImportadorExcelCsv.App;
using ImportadorExcelCsv.Infrastructure;
using ImportadorExcelCsv.Ui.Services;
using ImportadorExcelCsv.Ui.ViewModels;
using ImportadorExcelCsv.Ui.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ImportadorExcelCsv.Ui
{
  internal class Program
  {
    public static IHost AppHost { get; private set; } = default!;

    [STAThread]
    public static void Main(string[] args)
    {
      AppHost = CreateHostBuilder(args).Build();

      BuildAvaloniaApp()
          .StartWithClassicDesktopLifetime(args);
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
              config.AddUserSecrets<Program>(optional: true);
            })
            .ConfigureServices((context, services) =>
            {
              services.AddSingleton<IConfiguration>(context.Configuration);

              services.RegisterApplicationServices();
              services.RegisterInfrastructureServices(context.Configuration);

              services.AddTransient<MainWindow>();
              services.AddTransient<MainWindowViewModel>();
              services.AddSingleton<MessageBoxService>();
            });

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
  }
}