using Avalonia.Controls;
using ImportadorExcelCsv.Ui.ViewModels;

namespace ImportadorExcelCsv.Ui.Views;

public partial class MainWindow : Window
{
  public MainWindow()
  {
    InitializeComponent();
    DataContext = new MainWindowViewModel(this);
  }
}