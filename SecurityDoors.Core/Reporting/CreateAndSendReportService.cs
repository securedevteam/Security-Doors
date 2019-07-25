using SecurityDoors.Core.Enums;
using SecurityDoors.Core.Reporting.Implementations;
using System.Threading.Tasks;

namespace SecurityDoors.Core.Reporting
{
    // TODO: XML комментарии

    public class CreateAndSendReportService
    {
        public async Task<bool> RunServiceAsync(object models, ReportType type)
        {
            try
            {
                var pdfService = new PdfReportService();

                await Task.Run(() =>
                {
                    pdfService.AddHeader("Отчет по проходам через двери");
                    pdfService.AddText("Таблица 1.");
                    pdfService.AddTable(models, type);
                    pdfService.AddFooter();
                });

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
