using ClosedXML.Excel;
using ImportadorExcelCsv.Domain.Interfaces;
using ImportadorExcelCsv.Domain.Items;

namespace ImportadorExcelCsv.App.Readers;

public class ExcelItemReader : IItemReader
{
  public List<RawItemRow> Read(string filePath, bool hasHeader)
  {
    List<RawItemRow> rows = [];
    using XLWorkbook workbook = new XLWorkbook(filePath);
    IXLWorksheet worksheet = workbook.Worksheet(1);
    bool isFirstRow = true;

    foreach (IXLRow row in worksheet.RowsUsed())
    {
      if (hasHeader && isFirstRow)
      {
        isFirstRow = false;
        continue;
      }

      int rowNumber = hasHeader ? 2 : 1;

      rows.Add(new RawItemRow
      {
        RowNumber = rowNumber,
        SKU = row.Cell(1).GetValue<string>(),
        Name = row.Cell(2).GetValue<string>(),
        Price = row.Cell(3).GetValue<string>(),
        Stock = row.Cell(4).GetValue<string>(),
        Category = row.Cell(5).GetValue<string>(),
        Active = row.Cell(6).GetValue<string>()
      });
    }

    return rows;
  }
}
