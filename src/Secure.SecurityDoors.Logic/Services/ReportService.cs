using DinkToPdf;
using DinkToPdf.Contracts;
using Secure.SecurityDoors.Logic.Interfaces;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Logic.Services
{
    public class ReportService : IReportService
    {
        private readonly IConverter _converter;

        public ReportService(IConverter converter)
        {
            _converter = converter;
        }

        public Task<byte[]> GeneratePdfAsync(string html)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings
                {
                    Top = 25,
                    Bottom = 25
                }
            };

            var webSettings = new WebSettings
            {
                DefaultEncoding = "utf-8"
            };

            var headerSettings = new HeaderSettings
            {
                FontSize = 15,
                FontName = "Ariel",
                Right = "Page [page] of [toPage]",
                Line = true
            };

            var footerSettings = new FooterSettings
            {
                FontSize = 12,
                FontName = "Ariel",
                Center = "This is for demonstration purposes only.",
                Line = true
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = html,
                HeaderSettings = headerSettings,
                FooterSettings = footerSettings,
                WebSettings = webSettings
            };

            var htmlToPdfDocument = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects =
                {
                    objectSettings
                },
            };

            return Task.Run(() => _converter.Convert(htmlToPdfDocument));
        }
    }
}
