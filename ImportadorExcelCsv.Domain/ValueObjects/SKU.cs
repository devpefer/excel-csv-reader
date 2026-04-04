namespace ImportadorExcelCsv.Domain.ValueObjects;

public record SKU
{
  public string Code { get; }

  public SKU(string code)
  {
    if (string.IsNullOrWhiteSpace(code))
    {
      throw new DomainValidationException(nameof(SKU), "El código de SKU no puede ser nulo o vacío", code);
    }

    if (code.Length != 8)
    {
      throw new DomainValidationException(nameof(SKU), "El código de SKU debe tener exactamente 8 caracteres", code);
    }

    Code = code;
  }
  public static implicit operator string(SKU sku) => sku.Code;
  public static implicit operator SKU(string code) => new SKU(code);

  public override string ToString() => Code;
}
