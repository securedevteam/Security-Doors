using SecurityDoors.Core.ReportService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using IronPdf;
using SecurityDoors.Core.EmailService.Implementations;
using System.IO;

/// <summary>
/// Документация по IronPdf
/// https://ironpdf.com/docs/
/// </summary>

namespace SecurityDoors.Core.ReportService.Implementations
{
	public class PdfReportService : IReporting
	{
		private HtmlToPdf PdfRenderer = new HtmlToPdf();
		private string htmlCode = string.Empty;
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
			PdfRenderer.PrintOptions.FirstPageNumber = 1;
			PdfRenderer.PrintOptions.Header.DrawDividerLine = true;
			PdfRenderer.PrintOptions.Header.CenterText = header;
			PdfRenderer.PrintOptions.Header.FontFamily = "Helvetica,Arial";
			PdfRenderer.PrintOptions.Header.FontSize = 12;
		}

		public void AddFooter()
		{
			PdfRenderer.PrintOptions.Footer.DrawDividerLine = true;
			PdfRenderer.PrintOptions.Footer.FontFamily = "Arial";
			PdfRenderer.PrintOptions.Footer.FontSize = 10;
			PdfRenderer.PrintOptions.Footer.LeftText = "{date} {time}";
			PdfRenderer.PrintOptions.Footer.RightText = "{page} of {total-pages}";
		}
		public void AddTable(List<(DateTime PassingTime, string Status, string Location, string Comment, string Door, string Card)> table)
		{
			htmlCode += "<br/>";
			htmlCode += @"<table border=""1"" cellpadding=""5"" style = ""border-collapse: collapse; border: 1px solid black;"">";
			htmlCode +=
				$"<thead>" +
				$"<td>Время прохода</td>" +
				$"<td>Статус</td>" +
				$"<td>Расположение</td>" +
				$"<td>Коментарий</td>" +
				$"<td>Дверь</td>" +
				$"<td>Карта</td>" +
				$"</thead>";

			htmlCode += "<tbody>";
			foreach (var row in table)
			{
				htmlCode +=
					$"<tr>" +
					$"<td>{row.PassingTime.ToString()}</td>" +
					$"<td>{row.Status}</td>" +
					$"<td>{row.Location}</td>" +
					$"<td>{row.Comment}</td>" +
					$"<td>{row.Door}</td>" +
					$"<td>{row.Card}</td>" +
					$"</tr>";
			}
			htmlCode += "</tbody></table>";
		}

		public void AddText(string text)
		{
			htmlCode += $"<p>{text}</p>";
		}

		public void ClearDocument()
		{
			htmlCode = string.Empty;
		}

		public object GetResult()
		{
			throw new NotImplementedException();
		}
		public void SaveAsFile(string path = @"D:\tmp")
		{/*
			if (!File.Exists(path))
			{
				var file = File.Create(path);
				file.Close();
			}*/
			PdfRenderer.RenderHtmlAsPdf(htmlCode).SaveAs("D://url.pdf");
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
