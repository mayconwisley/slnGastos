using System;
using System.Security.Cryptography;
using System.Text;

namespace Criptografia
{
    public static class Criptografar
    {
        public static string CriptografarSenha(string chave, string senha)
        {
            using (var aes = Aes.Create())
            using (var sha256 = SHA256.Create())
            {
                // Gerar hash da chave (usando SHA-256) para garantir uma chave de 256 bits
                byte[] byteHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(chave));
                byte[] byteTexto = Encoding.UTF8.GetBytes(senha);

                aes.Key = byteHash;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aes.CreateEncryptor();
                byte[] encryptedBytes = encryptor.TransformFinalBlock(byteTexto, 0, byteTexto.Length);

                return Convert.ToBase64String(encryptedBytes);
            }
        }
    }
}
