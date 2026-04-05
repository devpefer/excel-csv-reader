using CommunityToolkit.Mvvm.ComponentModel;

namespace ImportadorExcelCsv.Ui.Models;

public partial class ItemGridRow : ObservableObject
{
  [ObservableProperty]
  private string sKU = string.Empty;

  [ObservableProperty]
  private string name = string.Empty;

  [ObservableProperty]
  private decimal price;

  [ObservableProperty]
  private int stock;

  [ObservableProperty]
  private string category = string.Empty;

  [ObservableProperty]
  private bool active;
}
