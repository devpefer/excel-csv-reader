namespace ImportadorExcelCsv.Domain.Interfaces;

public interface IItemReaderFactory
{
  IItemReader Create (string fileName);
}