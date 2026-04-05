using Avalonia.Controls;
using ImportadorExcelCsv.Ui.ViewModels;

namespace ImportadorExcelCsv.Ui.Views;

public partial class EditItemWindow : Window
{
  public EditItemWindow()
  {
    InitializeComponent();

    if (DataContext is EditItemWindowViewModel vm)
      vm.SetWindow(this);

    Opened += (_, _) =>
    {
      if (DataContext is EditItemWindowViewModel vmOpened)
        vmOpened.SetWindow(this);
    };
  }
}