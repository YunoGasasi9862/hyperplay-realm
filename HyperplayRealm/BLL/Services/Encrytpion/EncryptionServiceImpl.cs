using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Encrytpion
{
    public class EncryptionServiceImpl : IEncrypt
    {
        public Task<string> Encrypt(string key)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(key));
                return Task.FromResult(Convert.ToBase64String(bytes));
            }
        }

        public async Task<bool> IsHashValueSame(string hashedValue, string key)
        {
            bool result = (hashedValue == await Encrypt(key));
            return result;
        }
    }
}
