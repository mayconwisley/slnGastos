using System.Windows.Input;
using Gastos.Application.Usuarios;
using Gastos.Presentation.Servicos;

namespace Gastos.Presentation.ViewModels;

public sealed class LoginViewModel : ObservableObject
{
    private readonly AutenticarUsuarioHandler autenticarUsuarioHandler;
    private readonly ObterLembreteSenhaHandler obterLembreteSenhaHandler;
    private readonly ContextoSessao contextoSessao;
    private string login = string.Empty;
    private string senha = string.Empty;
    private string status = string.Empty;

    public LoginViewModel(
        AutenticarUsuarioHandler autenticarUsuarioHandler,
        ObterLembreteSenhaHandler obterLembreteSenhaHandler,
        ContextoSessao contextoSessao)
    {
        this.autenticarUsuarioHandler = autenticarUsuarioHandler;
        this.obterLembreteSenhaHandler = obterLembreteSenhaHandler;
        this.contextoSessao = contextoSessao;
        EntrarCommand = new AsyncRelayCommand(EntrarAsync);
        LembrarSenhaCommand = new AsyncRelayCommand(ObterLembreteAsync);
    }

    public event EventHandler? Autenticado;

    public string Login { get => login; set => SetProperty(ref login, value); }
    public string Senha { get => senha; set => SetProperty(ref senha, value); }
    public string Status { get => status; private set => SetProperty(ref status, value); }
    public ICommand EntrarCommand { get; }
    public ICommand LembrarSenhaCommand { get; }

    private async Task EntrarAsync()
    {
        try
        {
            var resultado = await autenticarUsuarioHandler.HandleAsync(
                new AutenticarUsuarioCommand(Login.Trim(), Senha),
                CancellationToken.None);
            if (!resultado.IsSuccess)
            {
                Status = string.Join(" ", resultado.Errors.Select(error => error.Description));
                return;
            }

            contextoSessao.Autenticar(Login.Trim());
            Autenticado?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception exception)
        {
            Status = $"Não foi possível autenticar: {exception.Message}";
        }
    }

    private async Task ObterLembreteAsync()
    {
        if (string.IsNullOrWhiteSpace(Login))
        {
            Status = "Informe o usuário para consultar o lembrete.";
            return;
        }

        var resultado = await obterLembreteSenhaHandler.HandleAsync(
            new ObterLembreteSenhaQuery(Login.Trim()),
            CancellationToken.None);
        Status = resultado.IsSuccess
            ? $"Lembrete: {resultado.Value}"
            : string.Join(" ", resultado.Errors.Select(error => error.Description));
    }
}
