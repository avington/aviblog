namespace AviBlog.Core.Encryption
{
    public interface IEncryptionHelper
    {
        string Encrypt(string text);
        bool CheckPassword(string hashedText,string plainText);
    }
}