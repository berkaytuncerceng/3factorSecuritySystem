using Microsoft.AspNetCore.Mvc;

namespace MVC_Layer.Controllers
{
	public class FaceRecognitionController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
