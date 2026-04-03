using CsvHelper;
using CsvHelper.Configuration;
using ImportadorExcelCsv.Domain.Interfaces;
using ImportadorExcelCsv.Domain.Items;
using System.Globalization;

namespace ImportadorExcelCsv.App.Readers;

public class CsvItemReader : IItemReader
{
  public List<RawItemRow> Read(string filePath, bool hasHeader)
  {
    List<RawItemRow> rows = [];
    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
    {
      Delimiter = ",",
      HasHeaderRecord = hasHeader
    };

    using var reader = new StreamReader(filePath);
    using var csv = new CsvReader(reader, config);

    if (hasHeader)
    {
      csv.Read();
      csv.ReadHeader();
    }

    int rowNumber = hasHeader ? 2 : 1;

    while (csv.Read())
    {
      rows.Add(new RawItemRow
      {
        RowNumber = rowNumber,
        SKU = csv.GetField(0) ?? string.Empty,
        Name = csv.GetField(1) ?? string.Empty,
        Price = csv.GetField(2) ?? string.Empty,
        Stock = csv.GetField(3) ?? string.Empty,
        Category = csv.GetField(4) ?? string.Empty,
        Active = csv.GetField(5) ?? string.Empty
      });

      rowNumber++;
    }

    return rows;
  }
}
