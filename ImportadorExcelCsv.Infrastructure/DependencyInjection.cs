using ImportadorExcelCsv.Domain.Interfaces.Repositories;
using ImportadorExcelCsv.Infrastructure.Data;
using ImportadorExcelCsv.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ImportadorExcelCsv.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
  {
    var connectionString = configuration["ConnectionString"]
      ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'ConnectionString'.");

    services.AddDbContext<ImportadorExcelCsvDbContext>(options =>
        options.UseSqlServer(connectionString));

    services.AddScoped<ICatalogRepository, CatalogRepository>();

    return services;
  }
}
