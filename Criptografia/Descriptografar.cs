using System;
using System.Security.Cryptography;
using System.Text;

namespace Criptografia
{
    public static class Descriptografar
    {
        static byte[] byteHash, byteTexto;

        public static string DescriptografarSenha(string chave, string senha)
        {
            TripleDESCryptoServiceProvider TDC = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byteHash = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(chave));
            byteTexto = Convert.FromBase64String(senha);
            md5.Clear();

            TDC.Key = byteHash;
            TDC.Mode = CipherMode.ECB;

            return ASCIIEncoding.ASCII.GetString(TDC.CreateDecryptor().TransformFinalBlock(byteTexto, 0, byteTexto.Length));
        }
    }
}
