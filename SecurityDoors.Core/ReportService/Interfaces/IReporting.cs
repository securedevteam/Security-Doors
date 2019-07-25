using System;
using System.Collections.Generic;

namespace SecurityDoors.Core.ReportService.Interfaces
{
    /// <summary>
    /// Интерфейс для отчета.
    /// </summary>
	public interface IReporting
	{
        /// <summary>
        /// Название документа.
        /// </summary>
		string DocumentName { get; set; }

		/// <summary>
		/// Добавляет текст в документ.
		/// </summary>
		/// <param name="text">текст.</param>
		void AddText(string text);

		/// <summary>
		/// Добавляет заголовок в документ.
		/// </summary>
		/// <param name="header">cодержимое.</param>
		void AddHeader(string header);

		/// <summary>
		/// Добавляет подвал на документ.
		/// </summary>
		void AddFooter();

		/// <summary>
		/// Добавляет таблицу в документ.
		/// </summary>
		/// <param name="table">таблица.</param>
		void AddTable(List<(DateTime PassingTime, string Status, string Location, string Comment, string Door, string Card)> table);

		/// <summary>
		/// Добавить изображение.
		/// </summary>
		/// <param name="sourcePath">пусть до изображения.</param>
		void AddImage(string sourcePath);

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
