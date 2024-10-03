using System;
using System.Security.Cryptography;

namespace Criptografia
{
    public static class Chave
    {
        public static string Gerar()
        {
            using (var aes = Aes.Create())
            {
                aes.GenerateKey();
                return Convert.ToBase64String(aes.Key);
            }
        }
    }
}
