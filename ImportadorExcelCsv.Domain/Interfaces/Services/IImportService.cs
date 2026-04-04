namespace ImportadorExcelCsv.Domain.Interfaces.Services;

public interface IImportService
{
  ImportResult Read(string filePath, bool hasHeader);
}
