using ImportadorExcelCsv.Domain;
using ImportadorExcelCsv.Domain.Interfaces;
using ImportadorExcelCsv.Domain.Items;
using ImportadorExcelCsv.Items;

namespace ImportadorExcelCsv.App.Services;

public class ImportService : IImportService
{
  IItemReaderFactory _itemReaderFactory;
  IItemRowMapper _mapper;

  public ImportService(IItemReaderFactory itemReaderFactory, IItemRowMapper mapper)
  {
    _itemReaderFactory = itemReaderFactory;
    _mapper = mapper;
  }

  public ImportResult Read(string filePath, bool hasHeader)
  {
    try
    {
      IItemReader reader = _itemReaderFactory.CreateItemFactory(filePath);
      List<RawItemRow> rawRows = reader.Read(filePath, hasHeader);

      ImportResult result = new ImportResult(rawRows.Count);

      foreach (RawItemRow rawRow in rawRows)
      {
        try
        {
          Item item = _mapper.Map(rawRow);
          result.Items.Add(item);
        }
        catch (ArgumentException ex)
        {
          result.Errors.Add(new ImportError
          {
            RowNumber = rawRow.RowNumber,
            Message = ex.Message
          });
        }
      }

      return result;
    }
    catch (Exception)
    {
      throw;
    }
  }
}