using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace ImportadorExcelCsv.Ui.ViewModels;

public partial class EditItemWindowViewModel : ObservableObject
{
  private Window? _window;

  [ObservableProperty]
  private string sku = string.Empty;
  private string oldSku = string.Empty;

  [ObservableProperty]
  private string name = string.Empty;
  private string oldName = string.Empty;

  [ObservableProperty]
  private string price = string.Empty;
  private string oldPrice = string.Empty;

  [ObservableProperty]
  private string stock = string.Empty;
  private string oldStock = string.Empty;

  [ObservableProperty]
  private string category = string.Empty;
  private string oldCategory = string.Empty;

  [ObservableProperty]
  private bool active;
  private bool oldActive;

  public bool WasUpdated { get; private set; }

  public Action<EditItemWindowViewModel>? OnUpdated { get; set; }

  public bool HasChanges =>
    Sku != oldSku ||
    Name != oldName ||
    Price != oldPrice ||
    Stock != oldStock ||
    Category != oldCategory ||
    Active != oldActive;

  public void Initialize(
    string sku,
    string name,
    string price,
    string stock,
    string category,
    bool active)
  {
    Sku = sku;
    Name = name;
    Price = price;
    Stock = stock;
    Category = category;
    Active = active;

    oldSku = sku;
    oldName = name;
    oldPrice = price;
    oldStock = stock;
    oldCategory = category;
    oldActive = active;

    OnPropertyChanged(nameof(HasChanges));
  }

  public void SetWindow(Window window)
  {
    _window = window;
  }

  [RelayCommand]
  private async Task Update()
  {
    if (!HasChanges)
    {
      WasUpdated = false;
      _window?.Close();
      return;
    }

    WasUpdated = true;
    OnUpdated?.Invoke(this);
    _window?.Close();
  }

  [RelayCommand]
  private void Exit()
  {
    WasUpdated = false;
    _window?.Close();
  }
}