using Microsoft.AspNetCore.Mvc;
using SecurityDoors.Core.ReportService.Implementations;
using System;

namespace SecurityDoors.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			//TODO: Delete me
			//var pdf = new PdfReportService();
			//pdf.AddHeader("Header");
			//var table = new System.Collections.Generic.List<(System.DateTime PassingTime, string Status, string Location, string Comment, string Door, string Card)> { };
			//table.Add((DateTime.Now,"Shatus epta", "Lokeishen", "Komment", "Dwer", "Karta"));
			//pdf.AddText("Ya tabliцo");
			//pdf.AddTable(table);
			//pdf.AddFooter();
			//pdf.SaveAsFile();
            return View();
        }
		public IActionResult About()
		{
			return View();
		}
	}
}