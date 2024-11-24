using Microsoft.AspNetCore.Mvc;

namespace MVC_Layer.Controllers
{
	public class FingerPrintController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
