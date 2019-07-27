using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;

namespace SecurityDoors.Core.Extensions
{
    /// <summary>
    /// Методы 
    /// </summary>
    public static class ReportExtensions
    {
        /// <summary>
        /// Конвертация типа отчета.
        /// </summary>
        /// <param name="reportType">тип отчета из модели.</param>
        /// <returns>Тип отчета в формате ReportType.</returns>
        public static ReportType ConvertType(this string reportType)
        {
            var rt = ReportType.IsNone;

            switch (reportType)
            {
                case ReportDataConstants.IS_EXCEL: { rt = ReportType.IsExcel; } break;
                case ReportDataConstants.IS_PDF: { rt = ReportType.IsPDF; } break;

                default: { } break;
            }

            return rt;
        }
    }
}
