using ImportadorExcelCsv.Domain.ValueObjects;
using ImportadorExcelCsv.Items;

namespace ImportadorExcelCsv.Domain.Interfaces.Repositories
{
  public interface IItemRepository
  {
    Task<Item?> GetByIdAsync(SKU sku);
    Task<List<Item>> GetAllAsync();
    Task AddAsync(Item item);
    void Update(Item entity);
    void Remove(Item entity);
    Task SaveChangesAsync();
  }
}
