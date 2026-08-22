namespace Gastos.Application.Usuarios;

public interface IPasswordCompatibilityVerifier
{
    bool Verificar(string senha, string senhaCriptografada, string chave);
}
