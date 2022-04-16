using Core.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Classes
{
    public class CipherService : ICipherService
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private const string Key = "NetCoreLayer";

        public CipherService(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
        }

        public string Encrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Protect(input);
        }

        public string Decrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Unprotect(input);
        }

        public string HashCreate(string value, string salt)
        {
            var valueBytes = Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivation.Pbkdf2(
                                     password: value,
                                     salt: System.Text.Encoding.UTF8.GetBytes(salt),
                                     prf: Microsoft.AspNetCore.Cryptography.KeyDerivation.KeyDerivationPrf.HMACSHA512,
                                     iterationCount: 10000,
                                     numBytesRequested: 256 / 8);

            //return System.Convert.ToBase64String(valueBytes);
            return System.Convert.ToBase64String(valueBytes) + "æ" + salt;
        }

        public bool ValidateHash(string value, string salt, string hash)
               //=> HashCreate(value, salt) == hash;
               => HashCreate(value, salt).Split('æ')[0] == hash;

        public string HashCreate()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return System.Convert.ToBase64String(randomBytes);
            }
        }
    }
}
