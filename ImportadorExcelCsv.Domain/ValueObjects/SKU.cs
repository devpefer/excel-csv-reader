namespace ImportadorExcelCsv.Domain.ValueObjects;

public record SKU
{
  public string Code { get; }

  public SKU(string code)
  {
    if (string.IsNullOrWhiteSpace(code))
    {
      throw new ArgumentNullException("El código de SKU no puede ser nulo o vacío");
    }

    if (code.Length != 8)
    {
      throw new ArgumentException("El código de SKU debe tener exactamente 8 caracteres");
    }

    Code = code;
  }
  public static implicit operator string(SKU sku) => sku.Code;
  public static implicit operator SKU(string code) => new SKU(code);

  public override string ToString() => Code;
}
