using System;
using System.Security.Cryptography;
using System.Text;
using Gareon.WebService.Logic.Abstractions.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Gareon.WebService.Logic.Cryptography
{
    public class Hasher : IHasher
    {
        public string CreateMd5Hash(string unhashed)
        {
            var bytes = Encoding.UTF8.GetBytes(unhashed);

            byte[] hash;

            using (var md5 = MD5.Create())
            {
                hash = md5.ComputeHash(bytes);
            }
            
            var builder = new StringBuilder();

            foreach (var @byte in hash)
            {
                builder.Append(@byte.ToString("X2"));
            }

            return builder.ToString().ToLower();
        }

        public string CreateSaltedHash(string unhashed, byte[] salt)
        {
            if (unhashed == null || string.IsNullOrWhiteSpace(unhashed))
            {
                throw new ArgumentException(nameof(unhashed));
            }

            if (salt == null) throw new ArgumentNullException(nameof(salt));

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(unhashed,
                salt, KeyDerivationPrf.HMACSHA512, 10000, 256 / 8));
        }

        public bool ValidatePasswordEquality(string unhashed, string hashed)
        {
            return this.CreateMd5Hash(unhashed) == hashed;
        }

        public bool ValidatePasswordEquality(string unhashed, string hashed, byte[] salt)
        {
            return this.CreateSaltedHash(unhashed, salt) == hashed;
        }

        public byte[] GenerateSalt()
        {
            var salt = new byte[128 / 8];

            using (var keyGenerator = RandomNumberGenerator.Create())
            {
                keyGenerator.GetBytes(salt);
            }

            return salt;
        }
    }
}