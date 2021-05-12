using System.Threading.Tasks;

namespace Secure.SecurityDoors.Logic.Interfaces
{
    /// <summary>
    /// Report service.
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// Generate PDF.
        /// </summary>
        /// <returns></returns>
        public Task<byte[]> GeneratePdfAsync(string html);
    }
}
