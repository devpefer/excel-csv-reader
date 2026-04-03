namespace ImportadorExcelCsv.Domain.Interfaces;

public interface IImportService
{
  ImportResult Read(string filePath, bool hasHeader);
}
