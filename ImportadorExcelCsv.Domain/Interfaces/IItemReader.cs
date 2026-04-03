using ImportadorExcelCsv.Domain.Items;

namespace ImportadorExcelCsv.Domain.Interfaces;

public interface IItemReader
{
  List<RawItemRow> Read(string filePath, bool hasHeader);
}