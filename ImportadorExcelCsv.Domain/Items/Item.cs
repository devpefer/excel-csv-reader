using ImportadorExcelCsv.Domain;
using ImportadorExcelCsv.Domain.Enums;
using ImportadorExcelCsv.Domain.ValueObjects;

namespace ImportadorExcelCsv.Items;

public class Item
{
  public SKU SKU { get; private set; }
  public string Name { get; private set; }
  public decimal Price { get; private set; }
  public int Stock { get; private set; }
  public Category Category { get; private set; }
  public bool Active { get; private set; }

  private Item() { }

  private Item(SKU sku, string name, decimal price, int stock, Category category, bool active)
  {
    SKU = sku;
    Name = name;
    Price = price;
    Stock = stock;
    Category = category;
    Active = active;
  }

  public static Item Create(SKU sku, string name, decimal price, int stock, Category category, bool active)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      throw new DomainValidationException(nameof(name), "El nombre no puede estar vacío.", name);
    }

    if (price <= 0)
    {
      throw new DomainValidationException(nameof(price), "El precio no puede ser 0 o inferior.", price);
    }

    if (stock < 0)
    {
      throw new DomainValidationException(nameof(stock), "El stock no puede ser inferior a 0.", stock);
    }

    return new Item(sku, name, price, stock, category, active);
  }
}
