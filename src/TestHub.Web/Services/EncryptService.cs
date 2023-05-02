using MimeKit.Encodings;
using System.Security.Cryptography;

namespace TestHub.Web.Services
{
    public static class EncryptService
    {
        private readonly static Aes aes = Aes.Create();

        public static string EncryptDateTimeOffset(DateTimeOffset dateTimeOffset)
        {
            var encryptor = aes.CreateEncryptor();

            using MemoryStream msEncrypt = new();
            using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new(csEncrypt))
            {
                swEncrypt.Write(dateTimeOffset);
            }
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public static DateTimeOffset DecryptDateTimeOffset(string encryptedDateTimeOffset)
        {
            var decryptor = aes.CreateDecryptor();
            string dateTimeOffset;
            using MemoryStream msDecrypt = new(Convert.FromBase64String(encryptedDateTimeOffset));
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using (StreamReader srDecrypt = new(csDecrypt))
            {
                dateTimeOffset = srDecrypt.ReadToEnd();
            }

            return DateTimeOffset.Parse(dateTimeOffset);
        }
    }
}