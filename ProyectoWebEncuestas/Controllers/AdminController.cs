using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EncuestasWeb.Controllers
{
    public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Detalles()
		{
			return View();
		}
		public IActionResult Encuestas()
		{
			return View();
		}
		public IActionResult AgregarEncuesta()
		{
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
		public IActionResult Usuarios()
		{
			return View();
		}
		public IActionResult AgregarUsuario()
		{
			return View();
		}
		public IActionResult EliminarUsuario()
		{
			return View();
		}

		public IActionResult Alumnos()
		{
			return View();
		}
		public IActionResult Respuestas()
		{
			return View();
		}
	}
}
