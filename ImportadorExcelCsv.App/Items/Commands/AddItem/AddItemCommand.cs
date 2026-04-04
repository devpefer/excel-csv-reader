using ImportadorExcelCsv.Domain.Enums;
using ImportadorExcelCsv.Domain.ValueObjects;
using MediatR;

namespace ImportadorExcelCsv.App.Items.Commands.AddItem;

public record AddItemCommand : IRequest
{
  public required SKU SKU { get; init; }
  public required string Name { get; init; }
  public required decimal Price { get; init; }
  public required int Stock { get; init; }
  public required Category Category { get; init; }
  public required bool Active { get; init; }
}
