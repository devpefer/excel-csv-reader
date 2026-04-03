using ImportadorExcelCsv.Domain.Items;
using ImportadorExcelCsv.Items;

namespace ImportadorExcelCsv.Domain.Interfaces;

public interface IItemRowMapper
{
  Item Map(RawItemRow row);
}
