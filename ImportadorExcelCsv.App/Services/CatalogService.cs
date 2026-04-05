using ImportadorExcelCsv.Domain.Enums;
using ImportadorExcelCsv.Domain.Interfaces.Repositories;
using ImportadorExcelCsv.Domain.Interfaces.Services;
using ImportadorExcelCsv.Domain.ValueObjects;
using ImportadorExcelCsv.Items;

namespace ImportadorExcelCsv.App.Services;

public class CatalogService : ICatalogService
{
  private readonly ICatalogRepository _catalogRepository;

  public CatalogService(ICatalogRepository catalogRepository)
  {
    _catalogRepository = catalogRepository;
  }

  public async Task<List<Item>> GetAllItemsAsync()
  {
    return await _catalogRepository.GetAllItemsAsync();
  }

  public async Task<Item> GetItemBySkuAsync(SKU sku)
  {
    Item item = await _catalogRepository.GetBySkuAsync(sku) ??
      throw new KeyNotFoundException($"El articulo {sku} no existe.");

    return item;
  }

  public async Task AddItemAsync(SKU sku, string name, decimal price, int stock, Category category, bool active)
  {
    if (await _catalogRepository.ExistsBySkuAsync(sku))
    {
      return;
    }

    Item item = Item.Create(sku, name, price, stock, category, active);

    await _catalogRepository.AddItemAsync(item);
    await _catalogRepository.SaveChangesAsync();
  }

  public async Task UpdateItemAsync(SKU sku, string name, decimal price, int stock, Category category, bool active)
  {
    Item item = await _catalogRepository.GetBySkuAsync(sku) ??
      throw new KeyNotFoundException($"El articulo {sku} no existe.");

    _catalogRepository.Update(item);
    await _catalogRepository.SaveChangesAsync();
  }
}
