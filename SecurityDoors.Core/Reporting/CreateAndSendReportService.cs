using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.Core.Reporting.Implementations;
using SecurityDoors.Core.Reporting.Interfaces;
using System.Threading.Tasks;

namespace SecurityDoors.Core.Reporting
{
    /// <summary>
    /// Сервис для создания и отправки отчета по email адресу.
    /// </summary>
    public class CreateAndSendReportService
    {
        private readonly IReportService _reportService;

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="reportType">тип отчета.</param>
        public CreateAndSendReportService(ReportType reportType)
        {
            switch (reportType)
            {
                case ReportType.IsExcel: { _reportService = new ExcelReportService(); } break;
                case ReportType.IsPDF: { _reportService = new PdfReportService(); } break;

                default: { } break;
            }
        }

        /// <summary>
        /// Запуск сервиса.
        /// </summary>
        /// <param name="models">модели (данные).</param>
        /// <param name="type">тип отчета.</param>
        /// <param name="header">заголовок.</param>
        /// <param name="description">описание.</param>
        /// <param name="footer">нижний колонтитул.</param>
        /// <param name="email">электронная почта.</param>
        /// <returns></returns>
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
