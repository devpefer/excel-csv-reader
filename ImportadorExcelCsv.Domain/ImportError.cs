namespace ImportadorExcelCsv.Domain;

public class ImportError
{
  public int RowNumber { get; init; }
  public string Message { get; init; } = string.Empty;
  public string? RawValue { get; init; }
  public string? FieldName { get; init; }
}
