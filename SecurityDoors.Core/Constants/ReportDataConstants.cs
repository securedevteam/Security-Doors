namespace SecurityDoors.Core.Constants
{
    /// <summary>
    /// Константы для отчета.
    /// </summary>
    public class ReportDataConstants
    {
        /// <summary>
        /// Тип Excel.
        /// </summary>
        public const string IS_EXCEL = "Excel";

        /// <summary>
        /// Тип PDF.
        /// </summary>
        public const string IS_PDF = "PDF";

        /// <summary>
        /// Стандартный путь.
        /// </summary>
        public const string DEFAULT_PATH = @"D:\sd_tmp";

        /// <summary>
        /// Стандартный диск.
        /// </summary>
        public const string DEFAULT_DISK = @"D:\";

        /// <summary>
        /// Стандартное расширение PDF документа.
        /// </summary>
        public const string FORMAT_PDF = ".pdf";

        /// <summary>
        /// Стандартное расширение Excel документа.
        /// </summary>
        public const string FORMAT_EXCEL = ".xlsx";

        /// <summary>
        /// Информация для описания в письме для PDF.
        /// </summary>
        public const string REPORT_PDF = "PDF отчет подготовлен: ";

        /// <summary>
        /// Информация для описания в письме для Excel.
        /// </summary>
        public const string REPORT_EXCEL = "EXCEL отчет подготовлен: ";

        /// <summary>
        /// Заголовок в таблице Excel.
        /// </summary>
        public const string EXCEL_TITLE = "От команды 30 commits to bug!";
    }
}
