// Controllers/HomeController.cs
using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
	private readonly IUserService _userService;

	public HomeController(IUserService userService)
	{
		_userService = userService;
	}

	// GET: Home/Index
	[HttpGet]
	public IActionResult Index()
	{
		return View(); // Views/Home/Index.cshtml dosyasını döndürür
	}

	// POST: Home/Add
	[HttpPost]
	public IActionResult Add(User user)
	{
		if (ModelState.IsValid) // Model doğrulama başarılı mı?
		{
			var result = _userService.Add(user); // Kullanıcıyı ekle
			if (result.Succeeded)
			{
				TempData["Message"] = "Kullanıcı başarıyla eklendi!";
				return RedirectToAction("Index"); // Başarıyla eklendiğinde Index'e yönlendir
			}
			else
			{
				TempData["Error"] = "Hata: " + result.Message;
			}
		}

		return View("Index"); // Hata durumunda tekrar Index görünümünü döndür
	}
}

