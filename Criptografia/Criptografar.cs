using System;
using System.Security.Cryptography;
using System.Text;

namespace Criptografia
{
    public static class Criptografar
    {
        static byte[] byteHash, byteTexto;

        public static string CriptografarSenha(string chave, string senha)
        {
            TripleDESCryptoServiceProvider TDC = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byteHash = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(chave));
            byteTexto = ASCIIEncoding.ASCII.GetBytes(senha);

            MD5.Clear();
            TDC.Key = byteHash;
            TDC.Mode = CipherMode.ECB;

            return Convert.ToBase64String(TDC.CreateEncryptor().TransformFinalBlock(byteTexto, 0, byteTexto.Length));
        }
    }
}
