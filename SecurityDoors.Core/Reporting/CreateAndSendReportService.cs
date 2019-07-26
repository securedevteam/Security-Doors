using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.Core.Reporting.Implementations;
using SecurityDoors.Core.Reporting.Interfaces;
using System.Threading.Tasks;

namespace SecurityDoors.Core.Reporting
{
    // TODO: XML комментарии

    public class CreateAndSendReportService
    {
        private readonly IReportService _reportService;

        public CreateAndSendReportService(ReportType reportType)
        {
            switch (reportType)
            {
                case ReportType.IsExcel: { _reportService = new ExcelReportService(); } break;
                case ReportType.IsPDF: { _reportService = new PdfReportService(); } break;

                default: { } break;
            }
        }

        public async Task<bool> RunServiceAsync(object models, ReportType type, string header, string description, string footer, string email)
        {
            try
            {
                await Task.Run(() =>
                {
                    _reportService.AddHeader(header);
                    _reportService.AddText(description);
                    _reportService.AddTable(models, type);
                    _reportService.AddFooter(footer);
					_reportService.SaveAsFile(ReportDataConstants.DEFAULT_DISK);
					_reportService.SendViaEmail(email, header);
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
