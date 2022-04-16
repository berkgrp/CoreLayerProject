namespace Core.Interfaces
{
    public interface ICipherService
    {
        string Encrypt(string cipherText);
        string Decrypt(string cipherText);
    }
}
