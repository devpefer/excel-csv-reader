using ImportadorExcelCsv.App.Dtos;
using ImportadorExcelCsv.Domain.Interfaces.Services;
using ImportadorExcelCsv.Items;
using MediatR;

namespace ImportadorExcelCsv.App.Items.Queries.GetAllItems;

public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, List<ItemDto>>
{
  private readonly ICatalogService _catalogService;

  public GetAllItemsQueryHandler(ICatalogService catalogService)
  {
    _catalogService = catalogService;
  }

  public async Task<List<ItemDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
  {
    List<Item> items = await _catalogService.GetAllItemsAsync();

    List<ItemDto> itemsDto = items
    .Select(x => new ItemDto
    {
      SKU = x.SKU,
      Name = x.Name,
      Price = x.Price,
      Stock = x.Stock,
      Category = x.Category,
      Active = x.Active
    })
    .ToList();

    return itemsDto;
  }
}
