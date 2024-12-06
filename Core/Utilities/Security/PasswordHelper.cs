﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security
{
	public static class PasswordHelper
	{
		// Hash a password using SHA256
		public static string HashPassword(string password)
		{
			using (var sha256 = SHA256.Create())
			{
				var bytes = Encoding.UTF8.GetBytes(password);
				var hash = sha256.ComputeHash(bytes);
				return Convert.ToBase64String(hash);
			}
		}

		// Verify if the plain password matches the hashed password
		public static bool VerifyPassword(string password, string hashedPassword)
		{
			var hashedInput = HashPassword(password);
			return hashedInput == hashedPassword;
		}
	}
}