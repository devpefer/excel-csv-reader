namespace ImportadorExcelCsv.Domain.Interfaces;

public interface IItemReaderFactory
{
  IItemReader CreateItemFactory (string fileName);
}