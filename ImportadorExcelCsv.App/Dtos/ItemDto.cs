using ImportadorExcelCsv.Domain.Enums;
using ImportadorExcelCsv.Domain.ValueObjects;

namespace ImportadorExcelCsv.App.Dtos;

public record ItemDto
{
  public required SKU SKU { get; init; }
  public required string Name { get; init; }
  public required decimal Price { get; init; }
  public required int Stock { get; init; }
  public required Category Category { get; init; }
  public required bool Active { get; init; }
}
