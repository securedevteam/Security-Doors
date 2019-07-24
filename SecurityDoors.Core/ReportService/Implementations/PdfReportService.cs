using SecurityDoors.Core.ReportService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using IronPdf;
using SecurityDoors.Core.EmailService.Implementations;
/// <summary>
/// Документация по IronPdf
/// https://ironpdf.com/docs/
/// </summary>
namespace SecurityDoors.Core.ReportService.Implementations
{
	public class PdfReportService : IReporting
	{
		private string documentName;
		public string DocumentName { get => documentName; set => documentName = value; }

		public PdfReportService(string documentName)
		{
			this.documentName = documentName ?? throw new ArgumentNullException(nameof(documentName));
		}

		public PdfReportService()
		{
			documentName = Guid.NewGuid().ToString();
		}

		public void AddHeader(string header)
		{
			throw new NotImplementedException();
		}

		public void AddTable(DataTable table)
		{
			throw new NotImplementedException();
		}

		public void AddText(string text)
		{
			throw new NotImplementedException();
		}

		public void ClearDocument()
		{
			throw new NotImplementedException();
		}

		public object GetResult()
		{
			throw new NotImplementedException();
		}

		public void SendViaEmail(string to, string subject)
		{
			///TODO: Почему не работает вот так?
			//var emailService = new EmailService();
			var emailService = new EmailService.Implementations.EmailService();
			_ = emailService.SendEmailAsync(to, subject, "Pdf отчет");
		}

		public void AddImage(string sourcePath)
		{
			throw new NotImplementedException();
		}
	}
}
