using ImportadorExcelCsv.App.Dtos;
using ImportadorExcelCsv.Domain.ValueObjects;
using MediatR;

namespace ImportadorExcelCsv.App.Items.Queries.GetItem;

public record GetItemQuery : IRequest<ItemDto?>
{
  public required SKU Sku { get; init; }
}
