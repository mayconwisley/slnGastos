using System.Security.Cryptography;
using System.Text;

namespace Criptografia
{
    public static class Chave
    {
        public static string Gerar()
        {
            DESCryptoServiceProvider desCrypto = (DESCryptoServiceProvider)DESCryptoServiceProvider.Create();
            return ASCIIEncoding.ASCII.GetString(desCrypto.Key);
        }
    }
}
