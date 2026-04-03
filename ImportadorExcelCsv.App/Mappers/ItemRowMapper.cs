using ImportadorExcelCsv.Domain;
using ImportadorExcelCsv.Domain.Enums;
using ImportadorExcelCsv.Domain.Interfaces;
using ImportadorExcelCsv.Domain.Items;
using ImportadorExcelCsv.Domain.ValueObjects;
using ImportadorExcelCsv.Items;
using System.Globalization;

namespace ImportadorExcelCsv.App.Mappers;

public class ItemRowMapper : IItemRowMapper
{
  CultureInfo culture = new CultureInfo("es-ES");

  public Item Map(RawItemRow row)
  {
    if (!decimal.TryParse(row.Price.Trim(), NumberStyles.Number, culture, out var price))
      throw new ItemMappingException(
          "El precio no es válido.",
          row.RowNumber,
          nameof(row.Price),
          string.IsNullOrWhiteSpace(row.Price) ? "(vacío)" : row.Price);

    if (!int.TryParse(row.Stock.Trim(), out var stock))
      throw new ItemMappingException(
          "El stock no es válido.",
          row.RowNumber,
          nameof(row.Stock),
          string.IsNullOrWhiteSpace(row.Stock) ? "(vacío)" : row.Stock);

    if (!Enum.TryParse<Category>(row.Category.Trim(), true, out var category))
      throw new ItemMappingException(
          "La categoría no es válida.",
          row.RowNumber,
          nameof(row.Category),
          string.IsNullOrWhiteSpace(row.Category) ? "(vacío)" : row.Category);

    if (!bool.TryParse(row.Active.Trim(), out var active))
      throw new ItemMappingException(
          "El valor de Activo no es válido.",
          row.RowNumber,
          nameof(row.Active),
          string.IsNullOrWhiteSpace(row.Active) ? "(vacío)" : row.Active);

    try
    {
      return Item.Create(
          new SKU(row.SKU.Trim()),
          row.Name.Trim(),
          price,
          stock,
          category,
          active
      );
    }
    catch (ArgumentException ex)
    {
      throw ConvertDomainException(ex, row);
    }
  }

  private static ItemMappingException ConvertDomainException(ArgumentException ex, RawItemRow row)
  {
    return ex.ParamName?.ToLower() switch
    {
      "name" => new ItemMappingException(ex.Message, row.RowNumber, nameof(row.Name), string.IsNullOrWhiteSpace(row.Name) ? "(vacío)" : row.Name),
      "price" => new ItemMappingException(ex.Message, row.RowNumber, nameof(row.Price), string.IsNullOrWhiteSpace(row.Price) ? "(vacío)" : row.Price),
      "stock" => new ItemMappingException(ex.Message, row.RowNumber, nameof(row.Stock), string.IsNullOrWhiteSpace(row.Stock) ? "(vacío)" : row.Stock),
      "category" => new ItemMappingException(ex.Message, row.RowNumber, nameof(row.Category), string.IsNullOrWhiteSpace(row.Category) ? "(vacío)" : row.Category),
      "active" => new ItemMappingException(ex.Message, row.RowNumber, nameof(row.Active), string.IsNullOrWhiteSpace(row.Active) ? "(vacío)" : row.Active),
      "sku" => new ItemMappingException(ex.Message, row.RowNumber, nameof(row.SKU), string.IsNullOrWhiteSpace(row.SKU) ? "(vacío)" : row.SKU),
      _ => new ItemMappingException(ex.Message, row.RowNumber)
    };
  }
}