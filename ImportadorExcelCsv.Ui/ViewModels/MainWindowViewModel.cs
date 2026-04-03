using Avalonia.Controls;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ImportadorExcelCsv.App.Factory;
using ImportadorExcelCsv.App.Mappers;
using ImportadorExcelCsv.App.Services;
using ImportadorExcelCsv.Domain;
using ImportadorExcelCsv.Domain.Interfaces;
using ImportadorExcelCsv.Ui.Models;
using ImportadorExcelCsv.Ui.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ImportadorExcelCsv.Ui.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
  private readonly IImportService _importService;
  private readonly TopLevel? _topLevel;
  private readonly MessageBoxService _messageBoxService;

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

  public ObservableCollection<ItemGridRow> Items { get; } = [];
  public ObservableCollection<ImportErrorGridRow> Errors { get; } = [];

  public MainWindowViewModel(TopLevel? topLevel = null)
  {
    _topLevel = topLevel;

    IItemReaderFactory factory = new ItemReaderFactory();
    IItemRowMapper mapper = new ItemRowMapper();
    _importService = new ImportService(factory, mapper);
    _messageBoxService = new MessageBoxService();
  }

  [RelayCommand]
  private async Task Browse()
  {
    if (_topLevel is null)
      return;

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
      return;

    try
    {
      ImportResult result = _importService.Read(FilePath, HasHeader);

      Items.Clear();
      Errors.Clear();

      foreach (var item in result.Items)
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

      foreach (var error in result.Errors)
      {
        Errors.Add(new ImportErrorGridRow
        {
          RowNumber = error.RowNumber,
          Message = error.Message,
          FieldName = error.FieldName,
          RawValue = error.RawValue
        });
      }

      TotalRowsText = $"Total filas: {result.TotalRows}";
      SuccessText = $"Válidas: {result.SuccesCount}";
      ErrorText = $"Errores: {result.ErrorCount}";
    }
    catch (Exception ex)
    {
      await _messageBoxService.ShowErrorAsync($"Ocurrió un error al importar el archivo: {ex.Message}");
    }
  }
}