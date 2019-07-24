using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SecurityDoors.Core.ReportService.Interfaces
{
	public interface IReporting<T>
	{
		string DocumentName { get; set; }

		/// <summary>
		/// Добавляет текст в документ
		/// </summary>
		/// <param name="text">Текст</param>
		void AddText(string text);
		/// <summary>
		/// Добавляет заголовок в документ
		/// </summary>
		/// <param name="header">Заголовок</param>
		void AddHeader(string header);
		/// <summary>
		/// Добавляет таблицу в документ
		/// </summary>
		/// <param name="table">Таблица</param>
		void AddTable(DataTable table);
		/// <summary>
		/// Очищает созданный документ
		/// </summary>
		void ClearDocument();
		/// <summary>
		/// Отправляет документ по почте
		/// </summary>
		/// <param name="to">e-mail получателя</param>
		/// <param name="subject">Заголовок письма</param>
		void SendViaEmail(string to, string subject);
		/// <summary>
		/// Возвращает документ
		/// </summary>
		/// <returns>Документ</returns>
		T GetResult();
	}
}
