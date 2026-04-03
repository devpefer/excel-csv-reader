using ImportadorExcelCsv.Items;

namespace ImportadorExcelCsv.Domain.Interfaces;

public interface IItemReader
{
  List<Item> Read(string filePath, bool hasHeader);
}