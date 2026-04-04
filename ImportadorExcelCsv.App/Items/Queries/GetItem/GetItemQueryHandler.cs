using ImportadorExcelCsv.App.Dtos;
using ImportadorExcelCsv.Domain.Interfaces.Services;
using ImportadorExcelCsv.Items;
using MediatR;

namespace ImportadorExcelCsv.App.Items.Queries.GetItem;

public class GetItemQueryHandler : IRequestHandler<GetItemQuery, ItemDto?>
{
  private readonly ICatalogService _catalogService;
  public GetItemQueryHandler(ICatalogService catalogService)
  {
    _catalogService = catalogService;
  }

  public async Task<ItemDto?> Handle(GetItemQuery request, CancellationToken cancellationToken)
  {
    Item item = await _catalogService.GetItemBySkuAsync(request.Sku);

    return new ItemDto
    {
      SKU = item.SKU,
      Name = item.Name,
      Price = item.Price,
      Stock = item.Stock,
      Category = item.Category,
      Active = item.Active
    };
  }
}
