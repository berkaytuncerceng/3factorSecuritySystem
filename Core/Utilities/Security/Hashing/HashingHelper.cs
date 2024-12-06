using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
	public static class HashingHelper
	{
		// Hash oluşturma
		public static string CreatePasswordHash(string password)
		{
			using (var sha256 = SHA256.Create())
			{
				var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
				return Convert.ToBase64String(hashedBytes); // Hashlenmiş string döndürülür
			} 
		}

		// Hash doğrulama
		public static bool VerifyPasswordHash(string password, string hashedPassword)
		{
			var hashOfInput = CreatePasswordHash(password);
			return hashOfInput == hashedPassword; // Eşleşme kontrolü
		}
	}
}
