namespace ImportadorExcelCsv.Domain.Items;

public class RawItemRow
{
  public int RowNumber { get; init; }
  public string SKU { get; init; } = string.Empty;
  public string Name { get; init; } = string.Empty;
  public string Price { get; init; } = string.Empty;
  public string Stock { get; init; } = string.Empty;
  public string Category { get; init; } = string.Empty;
  public string Active { get; init; } = string.Empty;
}
