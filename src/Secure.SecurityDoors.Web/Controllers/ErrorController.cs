using Microsoft.AspNetCore.Mvc;

namespace Secure.SecurityDoors.Web.Controllers
{
    [Route("error")]
    public class ErrorController : Controller
    {
        [Route("500")]
        public IActionResult AppError() => View();

        [Route("404")]
        public IActionResult PageNotFound() => View();
    }
}
