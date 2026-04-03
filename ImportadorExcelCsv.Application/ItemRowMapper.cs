using ImportadorExcelCsv.Domain.Enums;
using ImportadorExcelCsv.Domain.Interfaces;
using ImportadorExcelCsv.Domain.Items;
using ImportadorExcelCsv.Domain.ValueObjects;
using ImportadorExcelCsv.Items;
using System.Globalization;

namespace ImportadorExcelCsv.Application;

public class ItemRowMapper : IItemRowMapper
{
  CultureInfo culture = new CultureInfo("es-ES");

  public Item Map(RawItemRow row)
  {
    if (!Enum.TryParse<Category>(row.Category.Trim(), true, out var category))
      throw new ArgumentException($"Categoría no válida en fila {row.RowNumber}: {row.Category}");

    if (!decimal.TryParse(row.Price.Trim(), NumberStyles.Number, culture, out var price))
      throw new ArgumentException($"Precio no válido en fila {row.RowNumber}: {row.Price}");

    if (!int.TryParse(row.Stock.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out var stock))
      throw new ArgumentException($"Stock no válido en fila {row.RowNumber}: {row.Stock}");

    if (!bool.TryParse(row.Active.Trim(), out var active))
      throw new ArgumentException($"Activo no válido en fila {row.RowNumber}: {row.Active}");

    return Item.Create(
        new SKU(row.SKU.Trim()),
        row.Name.Trim(),
        price,
        stock,
        category,
        active
    );
  }
}
