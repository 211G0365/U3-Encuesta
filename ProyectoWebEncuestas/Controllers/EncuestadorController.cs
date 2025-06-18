using Microsoft.AspNetCore.Mvc;

namespace EncuestasWeb.Controllers
{
	public class EncuestadorController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult MisEncuestas()
		{
			return View();
		}
		public IActionResult AgregarEncuesta() {
			return View();
		}
		public IActionResult EditarEncuesta()
		{
			return View();
		}
		public IActionResult EliminarEncuesta()
		{
			return View();
		}
		public IActionResult Detalles()
		{
			return View();
		}
		public IActionResult AgregarRespuestas()
		{
			return View();
		}
		public IActionResult AplicarEncuesta()
		{
			return View();
		}
	}
}
