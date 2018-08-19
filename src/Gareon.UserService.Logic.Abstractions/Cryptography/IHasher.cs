namespace Gareon.UserService.Logic.Abstractions.Cryptography
{
    public interface IHasher
    {
        string CreateHash(string unhased);

        string CreateSaltedHash(string unhashed, byte[] salt);

        bool ValidatePasswordEquality(string unhashed, string hashed);
        
        bool ValidatePasswordEquality(string unhashed, string hashed, byte[] salt);

        byte[] GeneratelSalt();
    }
}