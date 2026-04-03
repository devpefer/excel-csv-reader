using ImportadorExcelCsv.Domain.Interfaces;

namespace ImportadorExcelCsv.Application;

public class ItemReaderFactory : IItemReaderFactory
{
  public IItemReader Create(string fileName)
  {
    string extension = Path.GetExtension(fileName);

    return extension switch
    {
      ".xlsx" => new ExcelItemReader(),
      ".csv" => new CsvItemReader(),
      _ => throw new NotImplementedException($"Extension {extension} is not implemented.")
    };
  }
}