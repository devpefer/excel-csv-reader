using ImportadorExcelCsv.Infrastructure.Data.Configurations;
using ImportadorExcelCsv.Items;
using Microsoft.EntityFrameworkCore;

namespace ImportadorExcelCsv.Infrastructure.Data;

public class ImportadorExcelCsvDbContext : DbContext
{
  public DbSet<Item> Items => Set<Item>();

  public ImportadorExcelCsvDbContext(DbContextOptions<ImportadorExcelCsvDbContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImportadorExcelCsv).Assembly);
    modelBuilder.ApplyConfiguration(new ItemConfiguration());
    base.OnModelCreating(modelBuilder);
  }
}