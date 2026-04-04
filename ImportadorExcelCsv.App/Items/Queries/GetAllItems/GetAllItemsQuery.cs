using ImportadorExcelCsv.App.Dtos;
using MediatR;

namespace ImportadorExcelCsv.App.Items.Queries.GetAllItems;

public class GetAllItemsQuery : IRequest<List<ItemDto>>
{
}
