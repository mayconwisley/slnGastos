using Gastos.Application.Clientes;
using Gastos.Application.Competencias;
using Gastos.Application.DespesasFixas;
using Gastos.Application.Emprestimos;
using Gastos.Application.Devedores;
using Gastos.Application.Movimentacoes;
using Gastos.Application.Painel;
using Gastos.Application.Usuarios;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmPrincipal : Form
{

    private string strLogin = string.Empty;
    private int idCliente;
    private int idCompetencia;
    private DateTime competencia;
    private bool carregandoClientes;
    private CadastrarClienteHandler cadastrarClienteHandler;
    private AtualizarClienteHandler atualizarClienteHandler;
    private ExcluirClienteHandler excluirClienteHandler;
    private ListarClientesHandler listarClientesHandler;
    private CadastrarCompetenciaHandler cadastrarCompetenciaHandler;
    private AtualizarCompetenciaHandler atualizarCompetenciaHandler;
    private ExcluirCompetenciaHandler excluirCompetenciaHandler;
    private ListarCompetenciasPorClienteHandler listarCompetenciasHandler;
    private CadastrarDespesaFixaHandler cadastrarDespesaFixaHandler;
    private AtualizarDespesaFixaHandler atualizarDespesaFixaHandler;
    private ExcluirDespesaFixaHandler excluirDespesaFixaHandler;
    private ListarDespesasFixasPorClienteHandler listarDespesasFixasHandler;
    private CadastrarEmprestimoHandler cadastrarEmprestimoHandler;
    private AtualizarEmprestimoHandler atualizarEmprestimoHandler;
    private ExcluirEmprestimoHandler excluirEmprestimoHandler;
    private GerarParcelasEmprestimoHandler gerarParcelasEmprestimoHandler;
    private ListarEmprestimosPorClienteHandler listarEmprestimosHandler;
    private CadastrarDevedorHandler cadastrarDevedorHandler;
    private AtualizarDevedorHandler atualizarDevedorHandler;
    private ExcluirDevedorHandler excluirDevedorHandler;
    private GerarParcelasDevedorHandler gerarParcelasDevedorHandler;
    private ListarDevedoresPorClienteHandler listarDevedoresHandler;
    private ListarResumoDevedoresPorClienteHandler listarResumoDevedoresHandler;
    private CadastrarMovimentacaoHandler cadastrarMovimentacaoHandler;
    private AtualizarMovimentacaoHandler atualizarMovimentacaoHandler;
    private ExcluirMovimentacaoHandler excluirMovimentacaoHandler;
    private ListarMovimentacoesPorCompetenciaHandler listarMovimentacoesHandler;
    private CadastrarParcelaEmprestimoHandler cadastrarParcelaEmprestimoHandler;
    private AtualizarParcelaEmprestimoHandler atualizarParcelaEmprestimoHandler;
    private ExcluirParcelaEmprestimoHandler excluirParcelaEmprestimoHandler;
    private ExcluirParcelasEmprestimoHandler excluirParcelasEmprestimoHandler;
    private QuitarEmprestimoHandler quitarEmprestimoHandler;
    private ListarParcelasEmprestimoHandler listarParcelasEmprestimoHandler;
    private CadastrarParcelaDevedorHandler cadastrarParcelaDevedorHandler;
    private AtualizarParcelaDevedorHandler atualizarParcelaDevedorHandler;
    private ExcluirParcelaDevedorHandler excluirParcelaDevedorHandler;
    private ExcluirParcelasDevedorHandler excluirParcelasDevedorHandler;
    private ListarParcelasDevedorHandler listarParcelasDevedorHandler;
    private ObterResumoPainelHandler obterResumoPainelHandler;
    private CadastrarUsuarioHandler cadastrarUsuarioHandler;
    private AtualizarUsuarioHandler atualizarUsuarioHandler;
    private ExcluirUsuarioHandler excluirUsuarioHandler;
    private ListarUsuariosHandler listarUsuariosHandler;
    public FrmPrincipal()
    {
        InitializeComponent();
    }

    public FrmPrincipal(string login, FrmPrincipalDependencies dependencies)
    {
        InitializeComponent();
        strLogin = login;
        cadastrarClienteHandler = dependencies.CadastrarCliente;
        atualizarClienteHandler = dependencies.AtualizarCliente;
        excluirClienteHandler = dependencies.ExcluirCliente;
        listarClientesHandler = dependencies.ListarClientes;
        cadastrarCompetenciaHandler = dependencies.CadastrarCompetencia;
        atualizarCompetenciaHandler = dependencies.AtualizarCompetencia;
        excluirCompetenciaHandler = dependencies.ExcluirCompetencia;
        listarCompetenciasHandler = dependencies.ListarCompetencias;
        cadastrarDespesaFixaHandler = dependencies.CadastrarDespesaFixa;
        atualizarDespesaFixaHandler = dependencies.AtualizarDespesaFixa;
        excluirDespesaFixaHandler = dependencies.ExcluirDespesaFixa;
        listarDespesasFixasHandler = dependencies.ListarDespesasFixas;
        cadastrarEmprestimoHandler = dependencies.CadastrarEmprestimo;
        atualizarEmprestimoHandler = dependencies.AtualizarEmprestimo;
        excluirEmprestimoHandler = dependencies.ExcluirEmprestimo;
        gerarParcelasEmprestimoHandler = dependencies.GerarParcelasEmprestimo;
        listarEmprestimosHandler = dependencies.ListarEmprestimos;
        cadastrarDevedorHandler = dependencies.CadastrarDevedor;
        atualizarDevedorHandler = dependencies.AtualizarDevedor;
        excluirDevedorHandler = dependencies.ExcluirDevedor;
        gerarParcelasDevedorHandler = dependencies.GerarParcelasDevedor;
        listarDevedoresHandler = dependencies.ListarDevedores;
        listarResumoDevedoresHandler = dependencies.ListarResumoDevedores;
        cadastrarMovimentacaoHandler = dependencies.CadastrarMovimentacao;
        atualizarMovimentacaoHandler = dependencies.AtualizarMovimentacao;
        excluirMovimentacaoHandler = dependencies.ExcluirMovimentacao;
        listarMovimentacoesHandler = dependencies.ListarMovimentacoes;
        cadastrarParcelaEmprestimoHandler = dependencies.CadastrarParcelaEmprestimo;
        atualizarParcelaEmprestimoHandler = dependencies.AtualizarParcelaEmprestimo;
        excluirParcelaEmprestimoHandler = dependencies.ExcluirParcelaEmprestimo;
        excluirParcelasEmprestimoHandler = dependencies.ExcluirParcelasEmprestimo;
        quitarEmprestimoHandler = dependencies.QuitarEmprestimo;
        listarParcelasEmprestimoHandler = dependencies.ListarParcelasEmprestimo;
        cadastrarParcelaDevedorHandler = dependencies.CadastrarParcelaDevedor;
        atualizarParcelaDevedorHandler = dependencies.AtualizarParcelaDevedor;
        excluirParcelaDevedorHandler = dependencies.ExcluirParcelaDevedor;
        excluirParcelasDevedorHandler = dependencies.ExcluirParcelasDevedor;
        listarParcelasDevedorHandler = dependencies.ListarParcelasDevedor;
        obterResumoPainelHandler = dependencies.ObterResumoPainel;
        cadastrarUsuarioHandler = dependencies.CadastrarUsuario;
        atualizarUsuarioHandler = dependencies.AtualizarUsuario;
        excluirUsuarioHandler = dependencies.ExcluirUsuario;
        listarUsuariosHandler = dependencies.ListarUsuarios;
    }


    public async Task ListarClienteAsync()
    {
        try
        {
            carregandoClientes = true;
            CbxCliente.DataSource = await GetListarClientesHandler()
                .HandleAsync(new ListarClientesQuery(), CancellationToken.None);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            carregandoClientes = false;
        }
    }


    private async Task AtualizarPainelAsync()
    {
        if (idCliente <= 0 || !DateTime.TryParseExact(MktCompetencia.Text.Trim(), "MM/yyyy", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"), System.Globalization.DateTimeStyles.None, out var dataReferencia))
        {
            return;
        }

        var resultado = await GetObterResumoPainelHandler().HandleAsync(
            new ObterResumoPainelQuery(idCliente, DateOnly.FromDateTime(dataReferencia)),
            CancellationToken.None);
        if (!resultado.IsSuccess)
        {
            LblSaldo.Text = "Saldo: 0,00";
            return;
        }

        var resumo = resultado.Value;
        idCompetencia = resumo.CompetenciaId;
        competencia = resumo.MesReferencia.ToDateTime(TimeOnly.MinValue);
        LblDespesaFixo.Text = $"Despesa Fixas......: {resumo.DespesasFixas:#,##0.00}";
        LblDespesaEmprestimo.Text = $"Despesa Empréstimos: {resumo.EmprestimosEmAberto:#,##0.00}";
        LblDebitoDevedores.Text = $"Débito Devedores...: {resumo.DebitosDevedores:#,##0.00}";
        LblCreditoDevedores.Text = $"Crédito Devedores..: {resumo.CreditosDevedores:#,##0.00}";
        LblSaldo.ForeColor = resumo.Saldo switch { > 0 => Color.Green, < 0 => Color.Red, _ => Color.Black };
        LblSaldo.Text = $"Saldo: {resumo.Saldo:#,##0.00}";
    }

    public void AtualizarFrmPrincipal() => _ = AtualizarDadosAsync();

    public async Task AtualizarDadosAsync()
    {
        try { await AtualizarPainelAsync(); }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private void SubMenuCadCliente_Click(object sender, EventArgs e)
    {
        FrmCadCliente frmCadCliente = new FrmCadCliente(
            this,
            strLogin,
            GetCadastrarClienteHandler(),
            GetAtualizarClienteHandler(),
            GetExcluirClienteHandler(),
            GetListarClientesHandler());
        frmCadCliente.ShowDialog();
    }

    private void SubMenuCadCompetencia_Click(object sender, EventArgs e)
    {
        FrmCadCompetencia frmCadCompetencia = new FrmCadCompetencia(
            this,
            GetListarClientesHandler(),
            GetCadastrarCompetenciaHandler(),
            GetAtualizarCompetenciaHandler(),
            GetExcluirCompetenciaHandler(),
            GetListarCompetenciasHandler());
        frmCadCompetencia.ShowDialog();
    }

    private void SubMenuCadUsuario_Click(object sender, EventArgs e)
    {
        FrmCadUsuario frmCadUsuario = new FrmCadUsuario(
            GetCadastrarUsuarioHandler(),
            GetAtualizarUsuarioHandler(),
            GetExcluirUsuarioHandler(),
            GetListarUsuariosHandler());
        frmCadUsuario.ShowDialog();
    }

    private void SubMenuFixCadastro_Click(object sender, EventArgs e)
    {
        FrmCadFixos frmCadFixos = new FrmCadFixos(
            this,
            strLogin,
            GetListarClientesHandler(),
            GetCadastrarDespesaFixaHandler(),
            GetAtualizarDespesaFixaHandler(),
            GetExcluirDespesaFixaHandler(),
            GetListarDespesasFixasHandler());
        frmCadFixos.ShowDialog();
    }

    private void SubMenuEmpCadastro_Click(object sender, EventArgs e)
    {
        FrmCadEmprestimo frmCadEmprestimo = new FrmCadEmprestimo(
            this,
            strLogin,
            GetListarClientesHandler(),
            GetCadastrarEmprestimoHandler(),
            GetAtualizarEmprestimoHandler(),
            GetExcluirEmprestimoHandler(),
            GetGerarParcelasEmprestimoHandler(),
            GetListarEmprestimosHandler());
        frmCadEmprestimo.ShowDialog();
    }

    private void SubMenuEmpMovimentacao_Click(object sender, EventArgs e)
    {
        FrmCadMovimentoEmprestimo frmCadMovimentoEmprestimo = new FrmCadMovimentoEmprestimo(
            this,
            strLogin,
            GetListarClientesHandler(),
            GetListarEmprestimosHandler(),
            GetCadastrarParcelaEmprestimoHandler(),
            GetAtualizarParcelaEmprestimoHandler(),
            GetExcluirParcelaEmprestimoHandler(),
            GetExcluirParcelasEmprestimoHandler(),
            GetQuitarEmprestimoHandler(),
            GetListarParcelasEmprestimoHandler());
        frmCadMovimentoEmprestimo.ShowDialog();
    }

    private void SubMenuDevCadastro_Click(object sender, EventArgs e)
    {
        FrmCadDevedores frmCadDevedores = new FrmCadDevedores(
            this,
            strLogin,
            GetListarClientesHandler(),
            GetCadastrarDevedorHandler(),
            GetAtualizarDevedorHandler(),
            GetExcluirDevedorHandler(),
            GetGerarParcelasDevedorHandler(),
            GetListarDevedoresHandler());
        frmCadDevedores.ShowDialog();
    }

    private void SubMenuDevMovimentacao_Click(object sender, EventArgs e)
    {
        FrmCadMovimentoDevedores frmCadMovimentoDevedores = new FrmCadMovimentoDevedores(
            this,
            strLogin,
            GetListarClientesHandler(),
            GetListarDevedoresHandler(),
            GetCadastrarParcelaDevedorHandler(),
            GetAtualizarParcelaDevedorHandler(),
            GetExcluirParcelaDevedorHandler(),
            GetExcluirParcelasDevedorHandler(),
            GetListarParcelasDevedorHandler());
        frmCadMovimentoDevedores.ShowDialog();
    }

    private void SubMenuMovCadastro_Click(object sender, EventArgs e)
    {
        FrmCadMovimentacao frmCadMovimentacao = new FrmCadMovimentacao(
            this,
            strLogin,
            GetListarClientesHandler(),
            GetListarCompetenciasHandler(),
            GetCadastrarMovimentacaoHandler(),
            GetAtualizarMovimentacaoHandler(),
            GetExcluirMovimentacaoHandler(),
            GetListarMovimentacoesHandler());
        frmCadMovimentacao.ShowDialog();
    }

    private void MenuSair_Click(object sender, EventArgs e)
    {
        System.Windows.Forms.Application.Exit();
    }

    private void TimeAtual_Tick(object sender, EventArgs e)
    {
        TsLblDataHora.Text = "Data: " + DateTime.Now.ToString("dd/MM/yyyy") + " Hora: " + DateTime.Now.ToString("HH:mm");
        TsLblUsuario.Text = "Usuário: " + strLogin;
    }

    private void SubMenuFixConsulta_Click(object sender, EventArgs e)
    {
        FrmConFixos frmConFixos = new FrmConFixos(GetListarClientesHandler(), GetListarDespesasFixasHandler());
        frmConFixos.ShowDialog();
    }

    private void SubMenuEmpConsulta_Click(object sender, EventArgs e)
    {
        FrmConEmprestimo frmConEmprestimo = new FrmConEmprestimo(GetListarClientesHandler(), GetListarEmprestimosHandler());
        frmConEmprestimo.ShowDialog();
    }

    private void SubMenuDevConsulta_Click(object sender, EventArgs e)
    {
        FrmConDevedores frmConDevedores = new FrmConDevedores(GetListarClientesHandler(), GetListarResumoDevedoresHandler());
        frmConDevedores.ShowDialog();
    }

    private void SubMenuMovConsulta_Click(object sender, EventArgs e)
    {
        FrmConMovimentacao frmConMovimentacao = new FrmConMovimentacao(
            GetListarClientesHandler(),
            GetListarCompetenciasHandler(),
            GetListarMovimentacoesHandler());
        frmConMovimentacao.ShowDialog();
    }

    private async void CbxCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carregandoClientes || CbxCliente.SelectedValue is not int clienteId)
        {
            return;
        }

        idCliente = clienteId;
        await AtualizarDadosAsync();
    }

    private async void FrmPrincipal_Load(object sender, EventArgs e)
    {
        MktCompetencia.Text = DateTime.Now.ToString("MM/yyyy");
        await ListarClienteAsync();
    }

    private async void MktCompetencia_Leave(object sender, EventArgs e)
    {
        await AtualizarDadosAsync();
    }

    private CadastrarClienteHandler GetCadastrarClienteHandler() =>
        cadastrarClienteHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private AtualizarClienteHandler GetAtualizarClienteHandler() =>
        atualizarClienteHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ExcluirClienteHandler GetExcluirClienteHandler() =>
        excluirClienteHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ListarClientesHandler GetListarClientesHandler() =>
        listarClientesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private CadastrarCompetenciaHandler GetCadastrarCompetenciaHandler() =>
        cadastrarCompetenciaHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private AtualizarCompetenciaHandler GetAtualizarCompetenciaHandler() =>
        atualizarCompetenciaHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ExcluirCompetenciaHandler GetExcluirCompetenciaHandler() =>
        excluirCompetenciaHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ListarCompetenciasPorClienteHandler GetListarCompetenciasHandler() =>
        listarCompetenciasHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private CadastrarDespesaFixaHandler GetCadastrarDespesaFixaHandler() =>
        cadastrarDespesaFixaHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private AtualizarDespesaFixaHandler GetAtualizarDespesaFixaHandler() =>
        atualizarDespesaFixaHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ExcluirDespesaFixaHandler GetExcluirDespesaFixaHandler() =>
        excluirDespesaFixaHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ListarDespesasFixasPorClienteHandler GetListarDespesasFixasHandler() =>
        listarDespesasFixasHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private CadastrarEmprestimoHandler GetCadastrarEmprestimoHandler() =>
        cadastrarEmprestimoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private AtualizarEmprestimoHandler GetAtualizarEmprestimoHandler() =>
        atualizarEmprestimoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ExcluirEmprestimoHandler GetExcluirEmprestimoHandler() =>
        excluirEmprestimoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private GerarParcelasEmprestimoHandler GetGerarParcelasEmprestimoHandler() =>
        gerarParcelasEmprestimoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ListarEmprestimosPorClienteHandler GetListarEmprestimosHandler() =>
        listarEmprestimosHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private CadastrarDevedorHandler GetCadastrarDevedorHandler() =>
        cadastrarDevedorHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private AtualizarDevedorHandler GetAtualizarDevedorHandler() =>
        atualizarDevedorHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ExcluirDevedorHandler GetExcluirDevedorHandler() =>
        excluirDevedorHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private GerarParcelasDevedorHandler GetGerarParcelasDevedorHandler() =>
        gerarParcelasDevedorHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ListarDevedoresPorClienteHandler GetListarDevedoresHandler() =>
        listarDevedoresHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ListarResumoDevedoresPorClienteHandler GetListarResumoDevedoresHandler() => listarResumoDevedoresHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private CadastrarMovimentacaoHandler GetCadastrarMovimentacaoHandler() =>
        cadastrarMovimentacaoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private AtualizarMovimentacaoHandler GetAtualizarMovimentacaoHandler() =>
        atualizarMovimentacaoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ExcluirMovimentacaoHandler GetExcluirMovimentacaoHandler() =>
        excluirMovimentacaoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ListarMovimentacoesPorCompetenciaHandler GetListarMovimentacoesHandler() =>
        listarMovimentacoesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private CadastrarParcelaEmprestimoHandler GetCadastrarParcelaEmprestimoHandler() => cadastrarParcelaEmprestimoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private AtualizarParcelaEmprestimoHandler GetAtualizarParcelaEmprestimoHandler() => atualizarParcelaEmprestimoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirParcelaEmprestimoHandler GetExcluirParcelaEmprestimoHandler() => excluirParcelaEmprestimoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirParcelasEmprestimoHandler GetExcluirParcelasEmprestimoHandler() => excluirParcelasEmprestimoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private QuitarEmprestimoHandler GetQuitarEmprestimoHandler() => quitarEmprestimoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarParcelasEmprestimoHandler GetListarParcelasEmprestimoHandler() => listarParcelasEmprestimoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private CadastrarParcelaDevedorHandler GetCadastrarParcelaDevedorHandler() => cadastrarParcelaDevedorHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private AtualizarParcelaDevedorHandler GetAtualizarParcelaDevedorHandler() => atualizarParcelaDevedorHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirParcelaDevedorHandler GetExcluirParcelaDevedorHandler() => excluirParcelaDevedorHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirParcelasDevedorHandler GetExcluirParcelasDevedorHandler() => excluirParcelasDevedorHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarParcelasDevedorHandler GetListarParcelasDevedorHandler() => listarParcelasDevedorHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private ObterResumoPainelHandler GetObterResumoPainelHandler() => obterResumoPainelHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

    private CadastrarUsuarioHandler GetCadastrarUsuarioHandler() => cadastrarUsuarioHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private AtualizarUsuarioHandler GetAtualizarUsuarioHandler() => atualizarUsuarioHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirUsuarioHandler GetExcluirUsuarioHandler() => excluirUsuarioHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarUsuariosHandler GetListarUsuariosHandler() => listarUsuariosHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");

}
