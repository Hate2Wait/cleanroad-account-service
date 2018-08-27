namespace Gareon.WebService.Logic.Abstractions.Cryptography
{
    public interface IHasher
    {
        string CreateMd5Hash(string unhashed);

        string CreateSaltedHash(string unhashed, byte[] salt);

        bool ValidatePasswordEquality(string unhashed, string hashed);
        
        bool ValidatePasswordEquality(string unhashed, string hashed, byte[] salt);

        byte[] GenerateSalt();
    }
}