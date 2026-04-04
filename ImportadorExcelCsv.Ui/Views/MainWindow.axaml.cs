using Avalonia.Controls;
using ImportadorExcelCsv.Ui.ViewModels;

namespace ImportadorExcelCsv.Ui.Views;

public partial class MainWindow : Window
{
  public MainWindow(MainWindowViewModel viewModel)
  {
    InitializeComponent();
    DataContext = viewModel;

    Opened += (_, _) =>
    {
      viewModel.SetTopLevel(this);
    };
  }
}