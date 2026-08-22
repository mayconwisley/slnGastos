using System.Collections.ObjectModel;
using System.Windows.Input;
using Gastos.Application.Usuarios;
using Gastos.Domain.Common;

namespace Gastos.Presentation.ViewModels;

public sealed class UsuariosViewModel : ObservableObject, IAtivavel
{
    private readonly CadastrarUsuarioHandler cadastrarHandler;
    private readonly AtualizarUsuarioHandler atualizarHandler;
    private readonly ExcluirUsuarioHandler excluirHandler;
    private readonly ListarUsuariosHandler listarHandler;
    private UsuarioDto? usuarioSelecionado;
    private string login = string.Empty;
    private string nome = string.Empty;
    private string lembrete = string.Empty;
    private string senha = string.Empty;
    private string confirmarSenha = string.Empty;
    private bool ativo = true;
    private string status = string.Empty;

    public UsuariosViewModel(CadastrarUsuarioHandler cadastrarHandler, AtualizarUsuarioHandler atualizarHandler, ExcluirUsuarioHandler excluirHandler, ListarUsuariosHandler listarHandler)
    {
        this.cadastrarHandler = cadastrarHandler;
        this.atualizarHandler = atualizarHandler;
        this.excluirHandler = excluirHandler;
        this.listarHandler = listarHandler;
        SalvarCommand = new AsyncRelayCommand(SalvarAsync);
        ExcluirCommand = new AsyncRelayCommand(ExcluirAsync);
        LimparCommand = new RelayCommand(_ => Limpar());
    }

    public ObservableCollection<UsuarioDto> Usuarios { get; } = [];
    public UsuarioDto? UsuarioSelecionado
    {
        get => usuarioSelecionado;
        set
        {
            if (SetProperty(ref usuarioSelecionado, value) && value is not null)
            {
                Login = value.Login;
                Nome = value.Nome;
                Lembrete = value.Lembrete;
                Ativo = value.EstaAtivo;
                Senha = string.Empty;
                ConfirmarSenha = string.Empty;
                OnPropertyChanged(nameof(LoginEditavel));
            }
        }
    }

    public string Login { get => login; set => SetProperty(ref login, value); }
    public string Nome { get => nome; set => SetProperty(ref nome, value); }
    public string Lembrete { get => lembrete; set => SetProperty(ref lembrete, value); }
    public string Senha { get => senha; set => SetProperty(ref senha, value); }
    public string ConfirmarSenha { get => confirmarSenha; set => SetProperty(ref confirmarSenha, value); }
    public bool Ativo { get => ativo; set => SetProperty(ref ativo, value); }
    public bool LoginEditavel => UsuarioSelecionado is null;
    public string Status { get => status; private set => SetProperty(ref status, value); }
    public ICommand SalvarCommand { get; }
    public ICommand ExcluirCommand { get; }
    public ICommand LimparCommand { get; }

    public Task AtivarAsync() => CarregarAsync();

    private async Task SalvarAsync()
    {
        if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Nome))
        {
            Status = "Informe login e nome.";
            return;
        }

        if (UsuarioSelecionado is null && string.IsNullOrWhiteSpace(Senha))
        {
            Status = "Informe a senha para cadastrar o usuário.";
            return;
        }

        if (!string.IsNullOrEmpty(Senha) && Senha != ConfirmarSenha)
        {
            Status = "A confirmação de senha não confere.";
            return;
        }

        Result resultado = UsuarioSelecionado is null
            ? await cadastrarHandler.HandleAsync(new CadastrarUsuarioCommand(Login, Nome, Senha, Lembrete, Ativo), CancellationToken.None)
            : await atualizarHandler.HandleAsync(new AtualizarUsuarioCommand(UsuarioSelecionado.Login, Nome, string.IsNullOrWhiteSpace(Senha) ? null : Senha, Lembrete, Ativo), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarAsync();
        }
    }

    private async Task ExcluirAsync()
    {
        if (UsuarioSelecionado is null)
        {
            Status = "Selecione um usuário para excluir.";
            return;
        }

        var resultado = await excluirHandler.HandleAsync(new ExcluirUsuarioCommand(UsuarioSelecionado.Login), CancellationToken.None);
        if (ExibirResultado(resultado))
        {
            Limpar();
            await CarregarAsync();
        }
    }

    private async Task CarregarAsync()
    {
        try
        {
            var usuarios = await listarHandler.HandleAsync(CancellationToken.None);
            Usuarios.Clear();
            foreach (var usuario in usuarios)
            {
                Usuarios.Add(usuario);
            }
        }
        catch (Exception exception)
        {
            Status = $"Não foi possível carregar os usuários: {exception.Message}";
        }
    }

    private bool ExibirResultado(Result resultado)
    {
        Status = resultado.IsSuccess ? "Operação concluída com sucesso." : string.Join(" ", resultado.Errors.Select(error => error.Description));
        return resultado.IsSuccess;
    }

    private void Limpar()
    {
        UsuarioSelecionado = null;
        Login = string.Empty;
        Nome = string.Empty;
        Lembrete = string.Empty;
        Senha = string.Empty;
        ConfirmarSenha = string.Empty;
        Ativo = true;
        OnPropertyChanged(nameof(LoginEditavel));
    }
}
