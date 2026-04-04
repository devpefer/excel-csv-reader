using ImportadorExcelCsv.Domain.Enums;
using ImportadorExcelCsv.Domain.ValueObjects;
using ImportadorExcelCsv.Items;

namespace ImportadorExcelCsv.Domain.Interfaces.Services;

public interface ICatalogService
{
  Task<List<Item>> GetAllItemsAsync();
  Task<Item> GetItemBySkuAsync(SKU sku);
  Task AddItemAsync(SKU sku, string name, decimal price, int stock, Category category, bool active);
}
