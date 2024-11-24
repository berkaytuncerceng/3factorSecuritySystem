using Microsoft.AspNetCore.Mvc;

namespace MVC_Layer.Controllers
{
	public class VerificationResultController : Controller
	{
		public IActionResult Success()
		{
			return View();
		}

		public IActionResult Failure()
		{
			return View();
		}
	}
}
