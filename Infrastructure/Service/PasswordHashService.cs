﻿using Application.Contract.IInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
	public class PasswordHashService : IPasswordHashService
	{
		private const int SALT_SIZE = 128 / 8;
		private const int KEY_SIZE = 256 / 8;
		private const int ITERATIONS = 10000;
		private const char DELIMITER = ';';
		private static readonly HashAlgorithmName _hashAlgorithmName = HashAlgorithmName.SHA256;

		public string Hash(string password)
		{
			var salt = RandomNumberGenerator.GetBytes(SALT_SIZE);
			var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, ITERATIONS, _hashAlgorithmName, KEY_SIZE);

			return string.Join(DELIMITER, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
		}

		public bool Verify(string passwordHash, string inputPassword)
		{
			var elements = passwordHash.Split(DELIMITER);
			var salt = Convert.FromBase64String(elements[0]);
			var hash = Convert.FromBase64String(elements[1]);

			var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, ITERATIONS, _hashAlgorithmName, KEY_SIZE);

			return CryptographicOperations.FixedTimeEquals(hash, hashInput);
		}
	}
}
