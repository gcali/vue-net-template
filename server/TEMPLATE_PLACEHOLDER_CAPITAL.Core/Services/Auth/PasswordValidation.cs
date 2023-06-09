using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Core.Services.Auth
{
    internal class PasswordValidation : IPasswordValidation
    {
        public bool IsSamePassword(string password, string hashed, byte[] salt)
        {
            return HashPassword(password, salt) == hashed;
        }

        public string HashPassword(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8)
            );
            return hashed;
        }

        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
    }
}