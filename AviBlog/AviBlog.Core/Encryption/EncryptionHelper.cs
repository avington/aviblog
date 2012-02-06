using DevOne.Security.Cryptography.BCrypt;

namespace AviBlog.Core.Encryption
{
    public class EncryptionHelper : IEncryptionHelper
    {
        public string Encrypt(string text)
        {
            string salt = BCryptHelper.GenerateSalt(6);
            var hashedPassword = BCryptHelper.HashPassword(text, salt);
            return hashedPassword;
        }

        public bool CheckPassword(string hashedText,string plainText)
        {
            return BCryptHelper.CheckPassword(plainText, hashedText);
        }


    }
}