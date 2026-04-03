using ImportadorExcelCsv.Application;
using ImportadorExcelCsv.Domain.Interfaces;
using ImportadorExcelCsv.Items;

string excelFileName = "/Users/devpefer/Downloads/articulos_ejemplo.xlsx";
string csvFileName = "/Users/devpefer/Downloads/articulos_ejemplo.csv";

IItemReader excelItemReader = ItemReaderFactory.Create(excelFileName);
IItemReader csvItemReader = ItemReaderFactory.Create(csvFileName);
List<Item> excelItems = excelItemReader.Read(excelFileName, true);
List<Item> csvItems = csvItemReader.Read(csvFileName, true);

foreach (Item item in excelItems)
{
  Console.WriteLine($"SKU: {item.SKU}\nName: {item.Name}\nPrice: {item.Price}\nStock: {item.Stock}\nCategory: {item.Category}\nActive: {item.Active}\n");
}

foreach (Item item in csvItems)
{
  Console.WriteLine($"SKU: {item.SKU}\nName: {item.Name}\nPrice: {item.Price}\nStock: {item.Stock}\nCategory: {item.Category}\nActive: {item.Active}\n");
}