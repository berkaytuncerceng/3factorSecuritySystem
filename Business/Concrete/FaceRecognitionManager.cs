using Business.Abstract;
using System.IO;

namespace Business.Concrete
{
	public class FaceRecognitionManager : IFaceRecognitionService
	{
		private readonly PythonExecutor _pythonExecutor;

		public FaceRecognitionManager(PythonExecutor pythonExecutor)
		{
			_pythonExecutor = pythonExecutor;
		}

		public async Task<bool> RegisterFaceAsync(string username, Stream imageStream)
		{
			var imagePath = SaveImageToTempFile(imageStream); // Görüntüyü geçici dosyaya kaydet
			var faceEncoding = _pythonExecutor.GetFaceEncoding(imagePath); // Yüz encoding verisini al

			if (faceEncoding != null)
			{
				// Yüz verisini veritabanına kaydetme işlemi yapılabilir
				// Burada kullanıcıya ait encoding verisini veritabanına eklemelisiniz

				// Örneğin:
				// await _userRepository.SaveFaceEncoding(username, faceEncoding);

				return true; // Yüz kaydı başarıyla yapıldı
			}

			return false; // Yüz verisi alınamadı
		}

		public Task<bool> ValidateFaceAsync(string username, Stream imageStream)
		{
			throw new NotImplementedException();
		}

		private string SaveImageToTempFile(Stream imageStream)
		{
			var tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".jpg");
			using (var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
			{
				imageStream.CopyTo(fileStream);
			}
			return tempFilePath; // Geçici dosyanın yolunu döndürüyoruz
		}
	}
}
