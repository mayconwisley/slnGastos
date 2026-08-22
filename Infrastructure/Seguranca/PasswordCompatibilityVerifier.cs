using Gastos.Application.Usuarios;
using System.Security.Cryptography;
using System.Text;

namespace Gastos.Infrastructure.Seguranca;

public sealed class PasswordCompatibilityVerifier : IPasswordCompatibilityVerifier
{
    public bool Verificar(string senha, string senhaCriptografada, string chave)
    {
        if (string.IsNullOrWhiteSpace(chave) || string.IsNullOrWhiteSpace(senhaCriptografada))
        {
            return false;
        }

        try
        {
            var senhaExistente = DescriptografarSenhaExistente(chave, senhaCriptografada);
            return CryptographicOperations.FixedTimeEquals(
                Encoding.UTF8.GetBytes(senha),
                Encoding.UTF8.GetBytes(senhaExistente));
        }
        catch (CryptographicException)
        {
            return false;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    private static string DescriptografarSenhaExistente(string chave, string senhaCriptografada)
    {
        using var aes = Aes.Create();
        using var sha256 = SHA256.Create();

        aes.Key = sha256.ComputeHash(Encoding.UTF8.GetBytes(chave));
        aes.Mode = CipherMode.ECB;
        aes.Padding = PaddingMode.PKCS7;

        var bytesCriptografados = Convert.FromBase64String(senhaCriptografada);
        var decryptor = aes.CreateDecryptor();
        var bytesDescriptografados = decryptor.TransformFinalBlock(
            bytesCriptografados,
            inputOffset: 0,
            inputCount: bytesCriptografados.Length);

        return Encoding.UTF8.GetString(bytesDescriptografados);
    }
}
