using ImportadorExcelCsv.Domain.Enums;
using ImportadorExcelCsv.Domain.Interfaces;
using ImportadorExcelCsv.Items;

namespace ImportadorExcelCsv.Application;

public class CsvItemReader : IItemReader
{
  public List<Item> Read(string filePath, bool hasHeader)
  {
    List<Item> items = [];

    return items;
  }

  private Item GetItem()
  {
    return Item.Create
    (
      row.Cell(1).GetValue<string>(),
      row.Cell(2).GetValue<string>(),
      row.Cell(3).GetValue<decimal>(),
      row.Cell(4).GetValue<int>(),
      row.Cell(5).GetValue<Category>(),
      row.Cell(6).GetValue<bool>()
    );
  }
}
