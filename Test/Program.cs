using ImportadorExcelCsv.Application;
using ImportadorExcelCsv.Items;

ExcelItemReader itemReader = new ExcelItemReader();
List<Item> items = itemReader.GetItemsWithHeader("C:\\Users\\devpefer\\Downloads\\articulos_ejemplo.xlsx");

foreach (Item item in items)
{
  Console.WriteLine($"SKU: {item.SKU}\nName: {item.Name}\nPrice: {item.Price}\nStock: {item.Stock}\nCategory: {item.Category}\nActive: {item.Active}\n");
}