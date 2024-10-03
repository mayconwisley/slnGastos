using System;
using System.Security.Cryptography;
using System.Text;

namespace Criptografia
{
    public static class Descriptografar
    {
        public static string DescriptografarSenha(string chave, string senhaCriptografada)
        {
            using (var aes = Aes.Create())
            using (var sha256 = SHA256.Create())
            {
                // Gerar hash da chave (usando SHA-256) para garantir uma chave de 256 bits
                byte[] byteHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(chave));
                byte[] byteTexto = Convert.FromBase64String(senhaCriptografada);

                aes.Key = byteHash;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aes.CreateDecryptor();
                byte[] decryptedBytes = decryptor.TransformFinalBlock(byteTexto, 0, byteTexto.Length);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}
