using ImportadorExcelCsv.Domain.Interfaces.Repositories;
using ImportadorExcelCsv.Domain.ValueObjects;
using ImportadorExcelCsv.Items;
using Microsoft.EntityFrameworkCore;

namespace ImportadorExcelCsv.Infrastructure.Data.Repositories;

public class CatalogRepository : ICatalogRepository
{
  private readonly ImportadorExcelCsvDbContext _context;

  public CatalogRepository(ImportadorExcelCsvDbContext context)
  {
    _context = context;
  }

  public async Task<bool> ExistsBySkuAsync(SKU sku)
  {
    return await _context.Items.AnyAsync(i => i.SKU == sku);
  }

  public async Task<Item?> GetBySkuAsync(SKU sku)
  {
    return await _context.Items.FindAsync(sku);
  }

  public async Task<List<Item>> GetAllItemsAsync()
  {
    return await _context.Items.ToListAsync();
  }

  public async Task AddItemAsync(Item entity)
  {
    await _context.Items.AddAsync(entity);
  }

  public void Update(Item entity)
  {
    _context.Items.Update(entity);
  }

  public void Remove(Item entity)
  {
    _context.Items.Remove(entity);
  }

  public Task SaveChangesAsync()
  {
    return _context.SaveChangesAsync();
  }
}
