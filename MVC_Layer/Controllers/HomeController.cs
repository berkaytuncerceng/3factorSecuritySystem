// Controllers/HomeController.cs
using Business.Abstract;
using Core.Utilities.Security.Hashing;
using Entities;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
	private readonly IUserService _userService;
	private readonly IFaceRecognitionService _faceRecognitionService;


	public HomeController(IUserService userService , IFaceRecognitionService faceRecognitionService)
	{
		_userService = userService;
		_faceRecognitionService = faceRecognitionService;

	}

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

	//[HttpPost]
	//public IActionResult Register(User user)
	//{
	//	if (ModelState.IsValid)
	//	{
	//		// PIN'i hashleyip saklama
	//		user.Pin = HashingHelper.CreatePasswordHash(user.Pin);

	//		user.CreatedAt = DateTime.Now;
	//		user.UpdatedAt = DateTime.Now;
	//		//user.FaceData = null; // Şimdilik boş bırakılıyor
	//		//user.FingerprintData = null; // Şimdilik boş bırakılıyor

	//		var result = _userService.Add(user); // Kullanıcıyı kaydet
	//		if (result.Succeeded)
	//		{
	//			TempData["SuccessMessage"] = "Kayıt başarılı! PIN ile giriş yapabilirsiniz.";
	//			return RedirectToAction("Index");
	//		}
	//		TempData["ErrorMessage"] = result.Message;
	//	}
	//	return View(user);
	//}
	[HttpPost]
	public async Task<IActionResult> Register(User user, string faceData)
	{
		// Kullanıcıyı kaydet
		var userId = _userService.Add(user);

		// FaceData'yı işlemek için kontrol
		if (!string.IsNullOrEmpty(faceData))
		{
			var faceStream = ConvertBase64ToStream(faceData);

			// Yüz tanıma işlemini başlat ve veritabanına kaydet
			bool isFaceRegistered = await _faceRecognitionService.RegisterFaceAsync(user.Username, faceStream);

			if (!isFaceRegistered)
			{
				TempData["Error"] = "Yüz verisi kaydedilemedi.";
				return View("Register", user);
			}
		}

		TempData["Success"] = "Kayıt başarılı!";
		return RedirectToAction("Index", "Home");
	}

	// Base64 veriyi Stream'e çeviren yardımcı metot
	private Stream ConvertBase64ToStream(string base64)
	{
		var data = Convert.FromBase64String(base64.Split(',')[1]);
		return new MemoryStream(data);
	}


	[HttpPost]
	public IActionResult Login(string Username, string Pin)
	{
		var user = _userService.GetAll().Data.FirstOrDefault(u => u.Username == Username);
		if (user != null)
		{
			// PIN doğrulama
			if (HashingHelper.VerifyPasswordHash(Pin, user.Pin))
			{
				// Doğrulama başarılı, yüz tanıma ekranına yönlendir
				return RedirectToAction("Index", "FaceRecognition");
			}
		}

		TempData["ErrorMessage"] = "Kullanıcı adı veya PIN yanlış!";
		return RedirectToAction("Index");
	}
}
