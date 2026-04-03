using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using ImportadorExcelCsv.Domain.Enums;
using ImportadorExcelCsv.Domain.Interfaces;
using ImportadorExcelCsv.Domain.ValueObjects;
using ImportadorExcelCsv.Items;

namespace ImportadorExcelCsv.Application;

public class CsvItemReader : IItemReader
{
  public List<Item> Read(string filePath, bool hasHeader)
  {
    List<Item> items = [];
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
    
    while (csv.Read())
    {
      items.Add(GetItem(csv));
    }
    
    return items;
  }

  private Item GetItem(CsvReader csv)
  {
    bool validCategory = Enum.TryParse(typeof(Category), csv.GetField("Categoria").Trim(), true, out var category);
    return Item.Create
    (
      new SKU(csv.GetField("SKU").Trim()),
      csv.GetField("Nombre").Trim(),
      decimal.Parse(csv.GetField("Precio"), CultureInfo.InvariantCulture),
      int.Parse(csv.GetField("Stock"), CultureInfo.InvariantCulture),
      (Category)category,
      bool.Parse(csv.GetField("Activo"))
    );
  }
}
