using ClosedXML.Excel;
using ImportadorExcelCsv.Domain.Enums;
using ImportadorExcelCsv.Items;

namespace ImportadorExcelCsv;

public class ItemReader
{
  public List<Item> GetItemsWithHeader(string filePath)
  {
    List<Item> items = [];
    using XLWorkbook workbook = new XLWorkbook(filePath);
    IXLWorksheet worksheet = workbook.Worksheet(1);
    bool isFirstRow = true;
    foreach (IXLRow row in worksheet.RowsUsed())
    {
      if (isFirstRow)
      {
        isFirstRow = false;
        continue;
      }
      items.Add(GetItem(row));
    }

    return items;
  }

  public List<Item> GetItemsWithoutHeader(string filePath)
  {
    List<Item> items = [];

    using XLWorkbook workbook = new XLWorkbook(filePath);
    IXLWorksheet worksheet = workbook.Worksheet(1);

    foreach (IXLRow row in worksheet.RowsUsed())
    {
      items.Add(GetItem(row));
    }

    return items;
  }

  private Item GetItem(IXLRow row)
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
