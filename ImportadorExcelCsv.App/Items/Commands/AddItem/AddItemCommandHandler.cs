using ImportadorExcelCsv.Domain.Interfaces.Services;
using MediatR;

namespace ImportadorExcelCsv.App.Items.Commands.AddItem;

public class AddItemCommandHandler : IRequestHandler<AddItemCommand>
{
  private readonly ICatalogService _catalogService;
  public AddItemCommandHandler(ICatalogService catalogService)
  {
    _catalogService = catalogService;
  }

  public async Task Handle(AddItemCommand request, CancellationToken cancellationToken)
  {
    await _catalogService.AddItemAsync(request.SKU, request.Name, request.Price, request.Stock, request.Category, request.Active);
  }
}
