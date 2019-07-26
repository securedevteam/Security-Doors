using OfficeOpenXml;
using SecurityDoors.Core.Enums;
using SecurityDoors.Core.Mailing.Implementations;
using SecurityDoors.Core.Models;
using SecurityDoors.Core.Reporting.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SecurityDoors.Core.Reporting.Implementations
{
	public class ExcelReportService : IReportService
	{
		private readonly string _documentName;
		private readonly string worksheetName = "Default";
		private string filePath;
		private ExcelPackage excel = new ExcelPackage();
		private int currentRow = 1;
		public string GetDocunetName => _documentName;
		public ExcelReportService(string documentName)
		{
			_documentName = documentName;
			AddSheet("Default");
		}

		public ExcelReportService()
		{
			_documentName = Guid.NewGuid().ToString();
			AddSheet("Default");
		}


		public void AddFooter(string footer)
		{
			currentRow++;
			var sheet = excel.Workbook.Worksheets[worksheetName];
			sheet.Cells[currentRow, 2].Value = "От команды SecurityDoors";
			currentRow++;
		}

		public void AddHeader(string header)
		{
			excel.Workbook.Properties.Title = header;
			excel.Workbook.Properties.Subject = header;
		}

		public void AddImage(string sourcePath)
		{
			throw new NotImplementedException();
		}

		public void AddTable(object models, ReportType type)
		{
			switch (type)
			{
				// Дополнять развидностями отчетов при необходимости.

				case ReportType.IsDoorPassing:
					{
						var data = (List<DoorPassingModel>)models;
						CreateDoorPassingTable(data);
					}
					break;

				default: { } break;
			}
		}

		private void CreateDoorPassingTable(List<DoorPassingModel> table)
		{
			var sheet = excel.Workbook.Worksheets[worksheetName];

			sheet.Cells[currentRow, 2].Value = "Id";
			sheet.Cells[currentRow, 3].Value = "Время прохода";
			sheet.Cells[currentRow, 4].Value = "Статус";
			sheet.Cells[currentRow, 5].Value = "Расположение";
			sheet.Cells[currentRow, 6].Value = "Комментарий";
			sheet.Cells[currentRow, 7].Value = "Дверь";
			sheet.Cells[currentRow, 8].Value = "Номер карты";

			currentRow++;

			foreach (var row in table)
			{
				sheet.Cells[currentRow, 2].Value = row.Id;
				sheet.Cells[currentRow, 3].Value = row.PassingTime;
				sheet.Cells[currentRow, 4].Value = row.Status;
				sheet.Cells[currentRow, 5].Value = row.Location;
				sheet.Cells[currentRow, 6].Value = row.Comment;
				sheet.Cells[currentRow, 7].Value = row.Door;
				sheet.Cells[currentRow, 8].Value = row.Card;
				currentRow++;
			}
		}
		public void AddText(string description)
		{
			var sheet = excel.Workbook.Worksheets[worksheetName];

			sheet.Cells[currentRow, 2].Value = description;

			currentRow++;
		}

		public void ClearDocument()
		{
			excel = new ExcelPackage();
			AddSheet(worksheetName);
		}

		public void SaveAsFile(string path = "D:\\tpm")
		{
			var filePath = $"{path}{_documentName}.xlsx";
			var fileInfo = new FileInfo(filePath);

			excel.SaveAs(fileInfo);

			this.filePath = filePath;
		}

		public void SendViaEmail(string to, string subject)
		{
			var attachment = new System.Net.Mail.Attachment(filePath);

			var emailService = new EmailService();
			_ = emailService.SendEmailAsync(to, subject, "Excel-отчет", attachment);
		}

		/// <summary>
		/// Добавляет новый лист в документ
		/// </summary>
		/// <param name="worksheetName">Название листа</param>
		private void AddSheet (string worksheetName)
		{
			excel.Workbook.Worksheets.Add(worksheetName);
		}
	}
}
