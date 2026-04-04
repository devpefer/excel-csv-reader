using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImportadorExcelCsv.Domain;
using ImportadorExcelCsv.Domain.Interfaces.Services;
using ImportadorExcelCsv.Items;
using ImportadorExcelCsv.Ui.Models;
using ImportadorExcelCsv.Ui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ImportadorExcelCsv.Ui.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
  private readonly IImportService _importService;
  private readonly ICatalogService _catalogService;
  private readonly MessageBoxService _messageBoxService;

  private TopLevel? _topLevel;
  private List<Item> _importedItems = [];

  [ObservableProperty]
  private string filePath = string.Empty;

  [ObservableProperty]
  private bool hasHeader = true;

  [ObservableProperty]
  private string totalRowsText = "Total filas: 0";

  [ObservableProperty]
  private string successText = "Válidas: 0";

  [ObservableProperty]
  private string errorText = "Errores: 0";

  [ObservableProperty]
  private string statusMessage = "Listo.";

  public ObservableCollection<ItemGridRow> Items { get; } = [];
  public ObservableCollection<ImportErrorGridRow> Errors { get; } = [];

  public MainWindowViewModel(
      IImportService importService,
      ICatalogService catalogService,
      MessageBoxService messageBoxService)
  {
    _importService = importService;
    _catalogService = catalogService;
    _messageBoxService = messageBoxService;
  }

  public void SetTopLevel(TopLevel topLevel)
  {
    _topLevel = topLevel;
  }

  [RelayCommand]
  private async Task Browse()
  {
    if (_topLevel is null)
    {
      await _messageBoxService.ShowErrorAsync("La ventana principal no está inicializada.");
      return;
    }

    var files = await _topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
    {
      Title = "Selecciona un archivo",
      AllowMultiple = false,
      FileTypeFilter =
        [
            new FilePickerFileType("Archivos soportados")
                {
                    Patterns = ["*.csv", "*.xlsx"]
                }
        ]
    });

    var file = files.FirstOrDefault();
    if (file is not null)
      FilePath = file.Path.LocalPath;
  }

  [RelayCommand]
  private async Task Import()
  {
    if (string.IsNullOrWhiteSpace(FilePath))
    {
      await _messageBoxService.ShowErrorAsync("Debes seleccionar un archivo.");
      return;
    }

    try
    {
      ImportResult result = _importService.Read(FilePath, HasHeader);

      _importedItems = result.Items.ToList();

      RefreshItemsGrid(result.Items);
      RefreshErrorsGrid(result.Errors);

      TotalRowsText = $"Total filas: {result.TotalRows}";
      SuccessText = $"Válidas: {result.SuccesCount}";
      ErrorText = $"Errores: {result.ErrorCount}";
      StatusMessage = "Importación realizada. Los datos todavía no se han guardado en la base de datos.";
    }
    catch (Exception ex)
    {
      await _messageBoxService.ShowErrorAsync($"Ocurrió un error al importar el archivo: {ex.Message}");
    }
  }

  [RelayCommand]
  private async Task SaveToDatabase()
  {
    if (_importedItems.Count == 0)
    {
      await _messageBoxService.ShowErrorAsync("No hay items importados para guardar.");
      return;
    }

    try
    {
      foreach (var item in _importedItems)
      {
        await _catalogService.AddItemAsync(
            item.SKU,
            item.Name,
            item.Price,
            item.Stock,
            item.Category,
            item.Active);
      }

      StatusMessage = $"Se guardaron {_importedItems.Count} items en la base de datos.";
    }
    catch (Exception ex)
    {
      await _messageBoxService.ShowErrorAsync($"Ocurrió un error al guardar en la base de datos: {ex.Message}");
    }
  }

  [RelayCommand]
  private async Task LoadFromDatabase()
  {
    try
    {
      var items = await _catalogService.GetAllItemsAsync();

      _importedItems = items.ToList();

      RefreshItemsGrid(items);
      Errors.Clear();

      TotalRowsText = $"Total filas: {items.Count}";
      SuccessText = $"Válidas: {items.Count}";
      ErrorText = "Errores: 0";
      StatusMessage = "Items cargados desde la base de datos.";
    }
    catch (Exception ex)
    {
      await _messageBoxService.ShowErrorAsync($"Ocurrió un error al recuperar los datos: {ex.Message}");
    }
  }

  [RelayCommand]
  private void Clear()
  {
    _importedItems.Clear();
    Items.Clear();
    Errors.Clear();

    FilePath = string.Empty;
    TotalRowsText = "Total filas: 0";
    SuccessText = "Válidas: 0";
    ErrorText = "Errores: 0";
    StatusMessage = "Datos limpiados.";
  }

  private void RefreshItemsGrid(IEnumerable<Item> items)
  {
    Items.Clear();

    foreach (var item in items)
    {
      Items.Add(new ItemGridRow
      {
        SKU = item.SKU.Code,
        Name = item.Name,
        Price = item.Price,
        Stock = item.Stock,
        Category = item.Category.ToString(),
        Active = item.Active
      });
    }
  }

  private void RefreshErrorsGrid(IEnumerable<ImportError> errors)
  {
    Errors.Clear();

    foreach (var error in errors)
    {
      Errors.Add(new ImportErrorGridRow
      {
        RowNumber = error.RowNumber,
        Message = error.Message,
        FieldName = error.FieldName,
        RawValue = error.RawValue
      });
    }
  }
}