using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Auction.DataAccess.Core
{
    public static class EncryptionProvider
    {
        private static readonly byte[] SaltBytes;

        static EncryptionProvider()
        {
            var saltHash = "4faea6e48d7741c6a2b6097a70320aaf";
            SaltBytes = Encoding.UTF8.GetBytes(saltHash);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var hashBytes = Convert.FromBase64String(hashedPassword);
            var salt = hashedPassword.Substring(0, 24);
            var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 4000);
            var testHashBytes = pbkdf2.GetBytes(32);

            return StructuralComparisons.StructuralEqualityComparer.Equals(hashBytes, testHashBytes);
        }

        public static string HashPassword(string password)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, SaltBytes, 4000);
            var hashBytes = pbkdf2.GetBytes(32);
            var saltString = Convert.ToBase64String(SaltBytes);
            var hashString = Convert.ToBase64String(hashBytes);
            return $"{saltString}{hashString}";
        }
    }
}
