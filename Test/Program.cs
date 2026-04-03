using ImportadorExcelCsv.Application;
using ImportadorExcelCsv.Domain;
using ImportadorExcelCsv.Domain.Interfaces;
using ImportadorExcelCsv.Items;

string excelFileName = "/Users/devpefer/Downloads/articulos_ejemplo.xlsx";
string csvFileName = "/Users/devpefer/Downloads/articulos_ejemplo.csv";

IItemReaderFactory itemReaderFactory = new ItemReaderFactory();
IItemRowMapper mapper = new ItemRowMapper();
IImportService importService = new ImportService(itemReaderFactory, mapper);

ImportResult excelResult = importService.Read(excelFileName, true);
ImportResult csvResult = importService.Read(csvFileName, true);

Console.WriteLine($"Excel result\n\nSuccess: {excelResult.SuccesCount}\nErrors: {excelResult.ErrorCount}\nTotal rows: {excelResult.TotalRows}\n");
Console.WriteLine($"CSV result\n\nSuccess: {csvResult.SuccesCount}\nErrors: {csvResult.ErrorCount}\nTotal rows: {csvResult.TotalRows}\n");

foreach (Item item in excelResult.Items)
{
  Console.WriteLine($"SKU: {item.SKU}\nName: {item.Name}\nPrice: {item.Price}\nCategory: {item.Category}\n\nActive: {item.Active}\n");
}

foreach (Item item in csvResult.Items)
{
  Console.WriteLine($"SKU: {item.SKU}\nName: {item.Name}\nPrice: {item.Price}\nCategory: {item.Category}\n\nActive: {item.Active}\n");
}
