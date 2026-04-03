using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using System.Threading.Tasks;

namespace ImportadorExcelCsv.Ui.Services
{
  internal class MessageBoxService
  {
    internal async Task ShowErrorAsync(string message)
    {
      var messageBox = MessageBoxManager
          .GetMessageBoxStandard("Error", message, ButtonEnum.Ok, Icon.Error);

      await messageBox.ShowAsync();
    }
  }
}
