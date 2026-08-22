using System.Windows.Input;
using Gastos.Application.Usuarios;
using Gastos.Domain.Common;

namespace Gastos.Presentation.ViewModels;

public sealed class CadastroInicialUsuarioViewModel : ObservableObject
{
    private readonly CadastrarUsuarioHandler cadastrarUsuarioHandler;
    private string login = string.Empty;
    private string nome = string.Empty;
    private string senha = string.Empty;
    private string confirmacaoSenha = string.Empty;
    private string lembrete = string.Empty;
    private string status = string.Empty;

    public CadastroInicialUsuarioViewModel(CadastrarUsuarioHandler cadastrarUsuarioHandler)
    {
        this.cadastrarUsuarioHandler = cadastrarUsuarioHandler;
        CriarUsuarioCommand = new AsyncRelayCommand(CriarUsuarioAsync);
    }

    public event EventHandler? UsuarioCriado;

    public string Login { get => login; set => SetProperty(ref login, value); }
    public string Nome { get => nome; set => SetProperty(ref nome, value); }
    public string Senha { get => senha; set => SetProperty(ref senha, value); }
    public string ConfirmacaoSenha { get => confirmacaoSenha; set => SetProperty(ref confirmacaoSenha, value); }
    public string Lembrete { get => lembrete; set => SetProperty(ref lembrete, value); }
    public string Status { get => status; private set => SetProperty(ref status, value); }
    public ICommand CriarUsuarioCommand { get; }

    private async Task CriarUsuarioAsync()
    {
        if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(Senha))
        {
            Status = "Informe login, nome e senha.";
            return;
        }

        if (Senha != ConfirmacaoSenha)
        {
            Status = "A confirmação de senha não confere.";
            return;
        }

        try
        {
            Result resultado = await cadastrarUsuarioHandler.HandleAsync(
                new CadastrarUsuarioCommand(Login.Trim(), Nome.Trim(), Senha, Lembrete.Trim(), true),
                CancellationToken.None);
            if (!resultado.IsSuccess)
            {
                Status = string.Join(" ", resultado.Errors.Select(error => error.Description));
                return;
            }

            UsuarioCriado?.Invoke(this, EventArgs.Empty);
        }
        catch (Exception exception)
        {
            Status = $"Não foi possível criar o usuário: {exception.Message}";
        }
    }
}
