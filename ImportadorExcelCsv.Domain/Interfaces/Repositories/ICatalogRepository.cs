using ImportadorExcelCsv.Domain.ValueObjects;
using ImportadorExcelCsv.Items;

namespace ImportadorExcelCsv.Domain.Interfaces.Repositories
{
  public interface ICatalogRepository
  {
    Task<bool> ExistsBySkuAsync(SKU sku);
    Task<Item?> GetBySkuAsync(SKU sku);
    Task<List<Item>> GetAllItemsAsync();
    Task AddItemAsync(Item item);
    void Update(Item entity);
    void Remove(Item entity);
    Task SaveChangesAsync();
  }
}
