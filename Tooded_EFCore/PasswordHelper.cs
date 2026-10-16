
using System;
using System.Security.Cryptography;

namespace Tooded_EFCore
{
    public static class PasswordHelper
    {
        public static string Hash(string parool)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                parool, salt, 100000,
                HashAlgorithmName.SHA256, 32);

            return Convert.ToBase64String(salt) + ":" +
                   Convert.ToBase64String(hash);
        }

        public static bool Verify(string parool, string paroolHash)
        {
            if (string.IsNullOrEmpty(paroolHash))
                return false;

            string[] osad = paroolHash.Split(':');

            if (osad.Length != 2)
                return false;

            try
            {
                byte[] salt = Convert.FromBase64String(osad[0]);
                byte[] vanaHash = Convert.FromBase64String(osad[1]);

                byte[] uusHash = Rfc2898DeriveBytes.Pbkdf2(
                    parool, salt, 100000,
                    HashAlgorithmName.SHA256, 32);

                return CryptographicOperations.FixedTimeEquals(
                    vanaHash, uusHash);
            }
            catch
            {
                return false;
            }
        }
    }
}