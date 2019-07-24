using Microsoft.AspNetCore.Mvc;
using SecurityDoors.Core.ReportService.Implementations;

namespace SecurityDoors.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			var pdf = new PdfReportService();
            return View();
        }
		public IActionResult About()
		{
			return View();
		}
	}
}