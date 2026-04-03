using ImportadorExcelCsv.Items;

namespace ImportadorExcelCsv.Domain;

public class ImportResult
{
  public List<Item> Items { get; init; } = [];
  public List<ImportError> Errors { get; init; } = [];
  public int TotalRows { get; set; }
  public int SuccesCount => Items.Count;
  public int ErrorCount => Errors.Count;

  public ImportResult(int totalRows)
  {
    TotalRows = totalRows;
  }
}
