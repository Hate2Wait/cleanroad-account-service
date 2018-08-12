using System.Security.Cryptography;
using CleanRoad.UserService.Logic.Abstractions.Cryptography;
using System.Text;

namespace CleanRoad.UserService.Logic.Cryptography
{
    public class Hasher : IHasher
    {
        public string CreateHash(string unhashed)
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

        public bool ValidatePasswordEquality(string unhashed, string hashed)
        {
            return this.CreateHash(unhashed) == hashed;
        }
    }
}