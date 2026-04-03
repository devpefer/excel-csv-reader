namespace ImportadorExcelCsv.Domain;

public class ItemMappingException : Exception
{
  public int RowNumber { get; }
  public string? FieldName { get; }
  public string? RawValue { get; }

  public ItemMappingException(string message, int rowNumber, string? fieldName = null, string? rawValue = null)
      : base(message)
  {
    RowNumber = rowNumber;
    FieldName = fieldName;
    RawValue = rawValue;
  }
}