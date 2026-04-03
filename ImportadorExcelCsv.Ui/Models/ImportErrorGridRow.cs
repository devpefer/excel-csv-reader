namespace ImportadorExcelCsv.Ui.Models;

public class ImportErrorGridRow
{
  public int RowNumber { get; set; }
  public string Message { get; set; } = string.Empty;
  public string? FieldName { get; set; }
  public string? RawValue { get; set; }
}