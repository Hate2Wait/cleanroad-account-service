namespace CleanRoad.UserService.Logic.Abstractions.Cryptography
{
    public interface IHasher
    {
        string CreateHash(string unhased);
    }
}