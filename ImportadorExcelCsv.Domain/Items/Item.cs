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

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
  private Item() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.

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
    return new Item(sku, name, price, stock, category, active);
  }

  public void UpdateBasicInfo(
    SKU sku,
    string name,
    decimal price,
    int stock,
    Category category,
    bool active)
  {


    SKU = new SKU(sku);
    Name = name;
    Price = price;
    Stock = stock;
    Category = category;
    Active = active;
  }

  private void ValidateItem(SKU sku, string name, decimal price, int stock, Category category, bool active)
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
  }
}
