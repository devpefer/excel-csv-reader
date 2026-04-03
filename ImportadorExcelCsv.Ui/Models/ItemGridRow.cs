namespace ImportadorExcelCsv.Ui.Models;

public class ItemGridRow
{
  public string SKU { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public decimal Price { get; set; }
  public int Stock { get; set; }
  public string Category { get; set; } = string.Empty;
  public bool Active { get; set; }
}
