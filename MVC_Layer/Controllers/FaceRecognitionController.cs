using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
	public class FaceRecognitionController : Controller
	{
		private readonly IFaceRecognitionService _faceRecognitionService;

		public FaceRecognitionController(IFaceRecognitionService faceRecognitionService)
		{
			_faceRecognitionService = faceRecognitionService;
		}

		// Yüz kaydı
		[HttpPost]
		public async Task<IActionResult> RegisterFace(IFormFile faceImage, string username)
		{
			if (faceImage == null || faceImage.Length == 0)
			{
				return BadRequest("Yüz verisi yüklenmedi.");
			}

			using (var stream = faceImage.OpenReadStream())
			{
				var result = await _faceRecognitionService.RegisterFaceAsync(username, stream);
				if (!result)
				{
					return BadRequest("Yüz kaydı işlemi başarısız oldu.");
				}
			}

			return Ok("Yüz kaydı başarılı!");
		}

		// Yüz doğrulama
		[HttpPost]
		public async Task<IActionResult> ValidateFace(IFormFile faceImage, string username)
		{
			if (faceImage == null || faceImage.Length == 0)
			{
				return BadRequest("Yüz verisi yüklenmedi.");
			}

			using (var stream = faceImage.OpenReadStream())
			{
				var result = await _faceRecognitionService.ValidateFaceAsync(username, stream);
				if (!result)
				{
					return BadRequest("Yüz doğrulama işlemi başarısız oldu.");
				}
			}

			return Ok("Yüz doğrulama başarılı!");
		}
	}
}
