namespace ImportadorExcelCsv.Domain;

public class DomainValidationException : Exception
{
  public string ParamName { get; }
  public object? Value { get; }

  public DomainValidationException(string paramName, string message, object? value = null)
      : base(message)
  {
    ParamName = paramName;
    Value = value;
  }
}
