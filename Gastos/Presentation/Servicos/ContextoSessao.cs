namespace Gastos.Presentation.Servicos;

public sealed class ContextoSessao
{
    public string Login { get; private set; } = string.Empty;

    public void Autenticar(string login)
    {
        Login = login;
    }
}
