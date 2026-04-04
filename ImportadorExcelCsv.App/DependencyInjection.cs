using ImportadorExcelCsv.App.Factory;
using ImportadorExcelCsv.App.Mappers;
using ImportadorExcelCsv.App.Readers;
using ImportadorExcelCsv.App.Services;
using ImportadorExcelCsv.Domain.Interfaces;
using ImportadorExcelCsv.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ImportadorExcelCsv.App;

public static class DependencyInjection
{
  public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
  {
    services.AddScoped<ICatalogService, CatalogService>();
    services.AddScoped<IImportService, ImportService>();
    services.AddScoped<IItemReaderFactory, ItemReaderFactory>();
    services.AddScoped<IItemReader, ExcelItemReader>();
    services.AddScoped<IItemReader, CsvItemReader>();
    services.AddScoped<IItemRowMapper, ItemRowMapper>();

    return services;
  }
}
