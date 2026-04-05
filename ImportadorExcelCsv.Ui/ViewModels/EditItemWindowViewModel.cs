using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace ImportadorExcelCsv.Ui.ViewModels;

public partial class EditItemWindowViewModel : ObservableObject
{
  private Window? _window;

  [ObservableProperty]
  private string sku = string.Empty;

  [ObservableProperty]
  private string name = string.Empty;

  [ObservableProperty]
  private string price = string.Empty;

  [ObservableProperty]
  private string stock = string.Empty;

  [ObservableProperty]
  private string category = string.Empty;

  [ObservableProperty]
  private bool active;

  public bool WasUpdated { get; private set; }

  public Action<EditItemWindowViewModel>? OnUpdated { get; set; }

  public void SetWindow(Window window)
  {
    _window = window;
  }

  [RelayCommand]
  private void Update()
  {
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