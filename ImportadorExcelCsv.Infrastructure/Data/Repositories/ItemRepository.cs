using ImportadorExcelCsv.Domain.Interfaces.Repositories;
using ImportadorExcelCsv.Domain.ValueObjects;
using ImportadorExcelCsv.Items;
using Microsoft.EntityFrameworkCore;

namespace ImportadorExcelCsv.Infrastructure.Data.Repositories;

public class ItemRepository : IItemRepository
{
  private readonly ImportadorExcelCsvDbContext _context;

  public ItemRepository(ImportadorExcelCsvDbContext context)
  {
    _context = context;
  }

  public async Task<Item?> GetByIdAsync(SKU sku)
  {
    return await _context.Items.FindAsync(sku);
  }

  public async Task<List<Item>> GetAllAsync()
  {
    return await _context.Items.ToListAsync();
  }

  public async Task AddAsync(Item entity)
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
