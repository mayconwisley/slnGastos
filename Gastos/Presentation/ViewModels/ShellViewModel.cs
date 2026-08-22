using System.Windows.Input;
using Gastos.Presentation.Servicos;

namespace Gastos.Presentation.ViewModels;

public sealed class ShellViewModel : ObservableObject
{
    private readonly FabricaPagina fabricaPagina;
    private readonly ServicoTema servicoTema;
    private readonly ContextoCompetencias contextoCompetencias;
    private ObservableObject? paginaAtual;
    private string tituloPagina = "Painel";

    public ShellViewModel(
        FabricaPagina fabricaPagina,
        ServicoTema servicoTema,
        ContextoSessao contextoSessao,
        ContextoCompetencias contextoCompetencias)
    {
        this.fabricaPagina = fabricaPagina;
        this.servicoTema = servicoTema;
        this.contextoCompetencias = contextoCompetencias;
        Usuario = contextoSessao.Login;
        OpcoesTema =
        [
            new OpcaoTema(PreferenciaTema.Automatico, "Automático (Windows)"),
            new OpcaoTema(PreferenciaTema.Claro, "Claro"),
            new OpcaoTema(PreferenciaTema.Escuro, "Escuro")
        ];
        this.servicoTema.TemaAlterado += AoAlterarTema;
        NavegarCommand = new RelayCommand(parameter =>
        {
            if (parameter is RotaPagina rota)
            {
                _ = NavegarAsync(rota);
            }
        });
        SairCommand = new RelayCommand(_ => System.Windows.Application.Current.Shutdown());
    }

    public string Usuario { get; }

    public ContextoCompetencias ContextoCompetencias => contextoCompetencias;

    public ObservableObject? PaginaAtual
    {
        get => paginaAtual;
        private set => SetProperty(ref paginaAtual, value);
    }

    public string TituloPagina
    {
        get => tituloPagina;
        private set => SetProperty(ref tituloPagina, value);
    }

    public IReadOnlyList<OpcaoTema> OpcoesTema { get; }

    public PreferenciaTema PreferenciaTema
    {
        get => servicoTema.Preferencia;
        set => servicoTema.DefinirPreferencia(value);
    }

    public ICommand NavegarCommand { get; }
    public ICommand SairCommand { get; }

    public async Task InicializarAsync()
    {
        await AtualizarCompetenciasAtivasAsync();
        await NavegarAsync(RotaPagina.Painel);
    }

    private async Task AtualizarCompetenciasAtivasAsync()
    {
        try
        {
            await contextoCompetencias.AtualizarAsync(CancellationToken.None);
        }
        catch (Exception)
        {
            contextoCompetencias.IndicarFalha();
        }
    }

    private async Task NavegarAsync(RotaPagina rota)
    {
        var pagina = fabricaPagina.Criar(rota);
        PaginaAtual = pagina;
        TituloPagina = ObterTitulo(rota);

        if (pagina is IAtivavel ativavel)
        {
            await ativavel.AtivarAsync();
        }
    }

    private void AoAlterarTema(object? sender, EventArgs e)
    {
        OnPropertyChanged(nameof(PreferenciaTema));
    }

    private static string ObterTitulo(RotaPagina rota)
    {
        return rota switch
        {
            RotaPagina.Painel => "Painel financeiro",
            RotaPagina.Clientes => "Cadastro de clientes",
            RotaPagina.Competencias => "Competências",
            RotaPagina.Usuarios => "Usuários",
            RotaPagina.DespesasFixasCadastro => "Despesas fixas · Cadastro",
            RotaPagina.DespesasFixasConsulta => "Despesas fixas · Consulta",
            RotaPagina.EmprestimosCadastro => "Empréstimos · Cadastro",
            RotaPagina.EmprestimosMovimentacao => "Empréstimos · Movimentação",
            RotaPagina.EmprestimosConsulta => "Empréstimos · Consulta",
            RotaPagina.DevedoresCadastro => "Devedores · Cadastro",
            RotaPagina.DevedoresMovimentacao => "Devedores · Movimentação",
            RotaPagina.DevedoresConsulta => "Devedores · Consulta",
            RotaPagina.MovimentacoesCadastro => "Movimentações · Cadastro",
            RotaPagina.MovimentacoesConsulta => "Movimentações · Consulta",
            _ => "Controle de gastos"
        };
    }
}
