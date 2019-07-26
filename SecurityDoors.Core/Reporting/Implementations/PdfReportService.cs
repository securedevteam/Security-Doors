using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using IronPdf;
using System.IO;
using SecurityDoors.Core.Mailing.Implementations;
using SecurityDoors.Core.Reporting.Interfaces;
using System.Threading.Tasks;
using SecurityDoors.Core.Enums;
using SecurityDoors.Core.Models;

/// <summary>
/// Документация по IronPdf
/// https://ironpdf.com/docs/
/// </summary>

// TODO: Добавить XML комментарии

namespace SecurityDoors.Core.Reporting.Implementations
{
    public class PdfReportService : IReportService
	{
		private HtmlToPdf PdfRenderer = new HtmlToPdf();
		private string htmlCode = string.Empty;

        private string _documentName;
		private string _filePath;

		public string GetDocunetName => _documentName;

		public PdfReportService(string documentName)
		{
			_documentName = documentName ?? throw new ArgumentNullException(nameof(documentName));
		}

		public PdfReportService()
		{
			_documentName = Guid.NewGuid().ToString();
		}

		public void AddHeader(string header)
		{
			PdfRenderer.PrintOptions.FirstPageNumber = 1;
			PdfRenderer.PrintOptions.Header.DrawDividerLine = true;
			PdfRenderer.PrintOptions.Header.CenterText = header;
			PdfRenderer.PrintOptions.Header.FontFamily = "Helvetica,Arial";
			PdfRenderer.PrintOptions.Header.FontSize = 12;
		}

		public void AddFooter(string footer)
		{
			PdfRenderer.PrintOptions.Footer.DrawDividerLine = true;
			PdfRenderer.PrintOptions.Footer.FontFamily = "Arial";
            PdfRenderer.PrintOptions.Header.CenterText = footer;
            PdfRenderer.PrintOptions.Footer.FontSize = 10;
			PdfRenderer.PrintOptions.Footer.LeftText = "{date} {time}";
			PdfRenderer.PrintOptions.Footer.RightText = "{page} of {total-pages}";
		}

		public void AddTable(object models, ReportType type)
		{
            switch (type)
            {
                // Дополнять развидностями отчетов при необходимости.

                case ReportType.IsDoorPassing:
                    {
                        var data = (List<DoorPassingModel>) models;
                        CreateDoorPassingTable(data);
                    }
                    break;

                default: { }  break;
            }
		}

        private void CreateDoorPassingTable(List<DoorPassingModel> table)
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

		public void AddText(string description)
		{
			htmlCode += $"<p>{description}</p>";
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
		{
			_filePath = $"{path}{_documentName}.pdf";
			PdfRenderer.RenderHtmlAsPdf(htmlCode).SaveAs(_filePath);
		}

		public void SendViaEmail(string to, string subject)
		{
			if (File.Exists(_filePath))
			{
				var attachedFile = new System.Net.Mail.Attachment(_filePath);
				var emailService = new EmailService();
				_ = emailService.SendEmailAsync(to, subject, "Pdf отчет", attachedFile);
			}
			else
			{
				///TODO: Написать это в логере
			}
		}

		public void AddImage(string sourcePath)
		{
			throw new NotImplementedException();
		}

	}
}
