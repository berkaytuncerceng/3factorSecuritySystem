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



	[HttpGet]
	public IActionResult Register()
	{
		return View();
	}

	[HttpPost]
	public IActionResult Register(User user)
	{
		if (ModelState.IsValid)
		{
			user.CreatedAt = DateTime.Now;
			user.UpdatedAt = DateTime.Now;
			user.FaceData = null; // Şimdilik boş bırakılıyor
			user.FingerprintData = null; // Şimdilik boş bırakılıyor

			var result = _userService.Add(user); // Kullanıcıyı kaydet
			if (result.Succeeded)
			{
				TempData["SuccessMessage"] = "Kayıt başarılı! PIN ile giriş yapabilirsiniz.";
				return RedirectToAction("Index");
			}
			TempData["ErrorMessage"] = result.Message;
		}
		return View(user);
	}



	[HttpPost]
	public IActionResult Login(string Username, string Pin)
	{
		var user = _userService.GetAll().Data.FirstOrDefault(u => u.Username == Username && u.Pin == Pin);
		if (user != null)
		{
			// Doğrulama başarılı, yüz tanıma ekranına yönlendir
			return RedirectToAction("Index", "FaceRecognition");
		}
		else
		{
			// Hata mesajı
			TempData["ErrorMessage"] = "Kullanıcı adı veya PIN yanlış!";
			return RedirectToAction("Index");
		}
	}





	//// POST: Home/Add
	//[HttpPost]
	//public IActionResult Add(User user)
	//{
	//	if (ModelState.IsValid) // Model doğrulama başarılı mı?
	//	{
	//		var result = _userService.Add(user); // Kullanıcıyı ekle
	//		if (result.Succeeded)
	//		{
	//			TempData["Message"] = "Kullanıcı başarıyla eklendi!";
	//			return RedirectToAction("Index"); // Başarıyla eklendiğinde Index'e yönlendir
	//		}
	//		else
	//		{
	//			TempData["Error"] = "Hata: " + result.Message;
	//		}
	//	}

	//	return View("Index"); // Hata durumunda tekrar Index görünümünü döndür
	//}
}

