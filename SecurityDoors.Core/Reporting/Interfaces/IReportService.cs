using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;

namespace SecurityDoors.Core.Reporting.Interfaces
{
    /// <summary>
    /// Интерфейс для отчета.
    /// </summary>
	public interface IReportService
	{
        /// <summary>
		/// Возвращает имя документа на сервере.
		/// </summary>
		string GetDocunetName { get; }

        /// <summary>
        /// Добавляет текст в документ.
        /// </summary>
        /// <param name="description">описание.</param>
        void AddText(string description);

		/// <summary>
		/// Добавляет заголовок в документ.
		/// </summary>
		/// <param name="header">cодержимое.</param>
		void AddHeader(string header);

        /// <summary>
        /// Добавляет подвал на документ.
        /// </summary>
        /// <param name="footer">cодержимое.</param>
        void AddFooter(string footer);

		/// <summary>
		/// Добавляет таблицу в документ.
		/// </summary>
		/// <param name="data">данные таблица.</param>
		void AddTable(object models, ReportType type);

		/// <summary>
		/// Сохраняет на сервере.
		/// </summary>
		/// <param name="path">путь к файлу</param>
		void SaveAsFile(string path = ReportDataConstants.DEFAULT_PATH);

		/// <summary>
		/// Очищает созданный документ.
		/// </summary>
		void ClearDocument();

		/// <summary>
		/// Отправляет документ по почте.
		/// </summary>
		/// <param name="to">e-mail получателя.</param>
		/// <param name="subject">заголовок письма.</param>
		void SendViaEmail(string to, string subject);
	}
}
