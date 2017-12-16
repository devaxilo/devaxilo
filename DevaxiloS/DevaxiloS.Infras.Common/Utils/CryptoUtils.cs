using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DevaxiloS.Infras.Common.Utils
{
    public static class CryptoUtils
    {
        public static byte[] EncryptPassword(string emailAddress, string password, string extraString = null)
        {
            var md5 = MD5.Create();
            return md5.ComputeHash(Encoding.UTF8.GetBytes($"{password}{emailAddress}{extraString}"));
        }

        public static bool VerifyPassword(string emailAddress, string password, byte[] currentPassword, string extraString = null)
        {
            var md5 = MD5.Create();
            byte[] encryptedPassword = md5.ComputeHash(Encoding.UTF8.GetBytes($"{password}{emailAddress}{extraString}"));

            return (currentPassword != null && currentPassword.SequenceEqual(encryptedPassword));
        }

        public static string ToVerificationCode(this string input)
        {
            if (string.IsNullOrWhiteSpace(input) || input.Length < 7)
                throw new ArgumentException("Error");
            return input.Substring(0, 6);
        }
    }
}
