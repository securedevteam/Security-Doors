using System;
using System.Collections.Generic;
using IronPdf;
using System.IO;
using SecurityDoors.Core.Mailing.Implementations;
using SecurityDoors.Core.Reporting.Interfaces;
using SecurityDoors.Core.Enums;
using SecurityDoors.Core.Models;
using SecurityDoors.Core.Constants;

/// <summary>
/// Документация по IronPdf
/// https://ironpdf.com/docs/
/// </summary>

namespace SecurityDoors.Core.Reporting.Implementations
{
    /// <summary>
    /// Сервис для подготовки PDF отчета.
    /// </summary>
    public class PdfReportService : IReportService
	{
		private HtmlToPdf PdfRenderer = new HtmlToPdf();
		private string htmlCode = string.Empty;

        private readonly string _documentName;
		private string _filePath;

        /// <inheritdoc/>
		public string GetDocunetName => _documentName;

        /// <summary>
        /// Конструктор с параметрами.
        /// </summary>
        /// <param name="documentName">название файла.</param>
		public PdfReportService(string documentName)
		{
			_documentName = documentName ?? throw new ArgumentNullException(nameof(documentName));
		}

        /// <summary>
        /// Пустой конструктор. Создает GUID название файла.
        /// </summary>
		public PdfReportService()
		{
			_documentName = Guid.NewGuid().ToString();
		}

        /// <inheritdoc/>
		public void AddHeader(string header)
		{
			PdfRenderer.PrintOptions.FirstPageNumber = 1;
			PdfRenderer.PrintOptions.Header.DrawDividerLine = true;
			PdfRenderer.PrintOptions.Header.CenterText = header;
			PdfRenderer.PrintOptions.Header.FontFamily = "Helvetica,Arial";
			PdfRenderer.PrintOptions.Header.FontSize = 12;
		}

        /// <inheritdoc/>
		public void AddFooter(string footer)
		{
			PdfRenderer.PrintOptions.Footer.DrawDividerLine = true;
			PdfRenderer.PrintOptions.Footer.FontFamily = "Arial";
            PdfRenderer.PrintOptions.Header.CenterText = footer;
            PdfRenderer.PrintOptions.Footer.FontSize = 10;
			PdfRenderer.PrintOptions.Footer.LeftText = "{date} {time}";
			PdfRenderer.PrintOptions.Footer.RightText = "{page} of {total-pages}";
		}

        /// <inheritdoc/>
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
                    $"<td>{row.UserAccount}</td>" +
                    $"<td>{row.Door}</td>" +
                    $"<td>{row.Card}</td>" +
                    $"</tr>";
            }

            htmlCode += "</tbody></table>";
        }

        /// <inheritdoc/>
		public void AddText(string description)
		{
			htmlCode += $"<p>{description}</p>";
		}

        /// <inheritdoc/>
		public void ClearDocument()
		{
			htmlCode = string.Empty;
		}

        /// <inheritdoc/>
		public void SaveAsFile(string path = ReportDataConstants.DEFAULT_PATH)
		{
			_filePath = $"{path}{_documentName}{ReportDataConstants.FORMAT_PDF}";
			PdfRenderer.RenderHtmlAsPdf(htmlCode).SaveAs(_filePath);
		}

        /// <inheritdoc/>
		public void SendViaEmail(string to, string subject)
		{
			if (File.Exists(_filePath))
			{
				var attachedFile = new System.Net.Mail.Attachment(_filePath);
				var emailService = new EmailService();
				_ = emailService.SendEmailAsync(to, subject, ReportDataConstants.REPORT_PDF + DateTime.Now, attachedFile);
			}
		}
	}
}
