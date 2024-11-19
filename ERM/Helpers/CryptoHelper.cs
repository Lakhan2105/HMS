using System.Security.Cryptography;

namespace ERM.Helpers
{
    public class CryptoHelper
    {
        private const int KeySize = 64;
        private const int iterations = 350000;
        private static readonly HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public static string HashPass(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(KeySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, KeySize);
            return Convert.ToHexString(hash);
        }

        public static bool isValidPass(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, KeySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        } 


    }
}
