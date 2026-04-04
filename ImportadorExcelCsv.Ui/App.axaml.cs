using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ImportadorExcelCsv.Ui.Views;
using Microsoft.Extensions.DependencyInjection;

namespace ImportadorExcelCsv.Ui
{
  public partial class App : Application
  {
    public override void Initialize()
    {
      AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
      if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
      {
        desktop.MainWindow = Program.AppHost.Services.GetRequiredService<MainWindow>();
      }

      base.OnFrameworkInitializationCompleted();
    }
  }
}