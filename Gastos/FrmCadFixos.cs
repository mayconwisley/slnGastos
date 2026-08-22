using Gastos.Application.Clientes;
using Gastos.Application.DespesasFixas;
using Gastos.Domain.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmCadFixos : Form
{
    private readonly FrmPrincipal frmPrincipal;
    private readonly string login;
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly CadastrarDespesaFixaHandler cadastrarHandler;
    private readonly AtualizarDespesaFixaHandler atualizarHandler;
    private readonly ExcluirDespesaFixaHandler excluirHandler;
    private readonly ListarDespesasFixasPorClienteHandler listarHandler;
    private int clienteId;
    private int despesaId;
    private bool carregandoClientes;

    public FrmCadFixos()
    {
        InitializeComponent();
    }

    public FrmCadFixos(FrmPrincipal frmPrincipal, string login, ListarClientesHandler listarClientesHandler, CadastrarDespesaFixaHandler cadastrarHandler, AtualizarDespesaFixaHandler atualizarHandler, ExcluirDespesaFixaHandler excluirHandler, ListarDespesasFixasPorClienteHandler listarHandler)
    {
        InitializeComponent();
        this.frmPrincipal = frmPrincipal;
        this.login = login;
        this.listarClientesHandler = listarClientesHandler;
        this.cadastrarHandler = cadastrarHandler;
        this.atualizarHandler = atualizarHandler;
        this.excluirHandler = excluirHandler;
        this.listarHandler = listarHandler;
    }

    private async Task CarregarClientesAsync()
    {
        carregandoClientes = true;
        try
        {
            CbxCliente.DisplayMember = nameof(ClienteDto.Nome);
            CbxCliente.ValueMember = nameof(ClienteDto.Id);
            CbxCliente.DataSource = await GetListarClientesHandler().HandleAsync(new ListarClientesQuery(), CancellationToken.None);
        }
        finally { carregandoClientes = false; }
    }

    private async Task CarregarDespesasAsync()
    {
        DgvListarFixos.DataSource = clienteId <= 0 ? null : await GetListarHandler().HandleAsync(new ListarDespesasFixasPorClienteQuery(clienteId), CancellationToken.None);
        AtualizarTotais();
    }

    private async Task ExecutarAsync(Operacao operacao)
    {
        if (!TryObterDados(out var inicio, out var fim, out var valor)) return;
        try
        {
            Result resultado = operacao switch
            {
                Operacao.Cadastrar => await CadastrarAsync(inicio, fim, valor),
                Operacao.Atualizar => await GetAtualizarHandler().HandleAsync(new AtualizarDespesaFixaCommand(despesaId, inicio, TxtDescricao.Text, valor, fim), CancellationToken.None),
                Operacao.Excluir => await GetExcluirHandler().HandleAsync(new ExcluirDespesaFixaCommand(despesaId), CancellationToken.None),
                _ => throw new ArgumentOutOfRangeException(nameof(operacao))
            };
            if (!resultado.IsSuccess) { MessageBox.Show(string.Join(Environment.NewLine, resultado.Errors.Select(error => error.Description))); return; }
            LimparCampos();
            await CarregarDespesasAsync();
        }
        catch (Exception ex) { MessageBox.Show($"Não foi possível concluir a operação: {ex.Message}"); }
    }

    private async Task<Result> CadastrarAsync(DateOnly inicio, DateOnly? fim, decimal valor)
    {
        var resultado = await GetCadastrarHandler().HandleAsync(new CadastrarDespesaFixaCommand(inicio, TxtDescricao.Text, valor, fim, login, clienteId), CancellationToken.None);
        return resultado.IsSuccess ? Result.Success() : Result.Failure(resultado.Errors.ToArray());
    }

    private bool TryObterDados(out DateOnly inicio, out DateOnly? fim, out decimal valor)
    {
        inicio = default; fim = null; valor = 0m;
        if (!DateTime.TryParseExact(MktDataInicio.Text.Trim(), "dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out var dataInicio)) { MessageBox.Show("Informe uma data inicial válida."); return false; }
        DateTime? dataFim = null;
        if (MktDataFim.MaskCompleted)
        {
            if (!DateTime.TryParseExact(MktDataFim.Text.Trim(), "dd/MM/yyyy", CultureInfo.GetCultureInfo("pt-BR"), DateTimeStyles.None, out var dataFinal)) { MessageBox.Show("Informe uma data final válida."); return false; }
            dataFim = dataFinal;
        }
        if (!decimal.TryParse(TxtValor.Text, NumberStyles.Number, CultureInfo.GetCultureInfo("pt-BR"), out valor)) { MessageBox.Show("Informe um valor válido."); return false; }
        inicio = DateOnly.FromDateTime(dataInicio);
        if (dataFim.HasValue) fim = DateOnly.FromDateTime(dataFim.Value);
        return true;
    }

    private void LimparCampos()
    {
        despesaId = 0; TxtDescricao.Clear(); MktDataInicio.Clear(); MktDataFim.Clear(); TxtValor.Text = "0,00";
        BtnAlterar.Enabled = false; BtnExcluir.Enabled = false; BtnSalvar.Enabled = true; MktDataInicio.Focus();
    }

    private void AtualizarTotais()
    {
        var despesas = DgvListarFixos.DataSource as IReadOnlyList<DespesaFixaDto> ?? [];
        var ativas = despesas.Where(item => item.Ativa).Sum(item => item.Valor);
        var inativas = despesas.Where(item => !item.Ativa).Sum(item => item.Valor);
        LblTotalAtivo.Text = $"Total Ativo...: {ativas:#,##0.00}";
        LblTotalNAtivo.Text = $"Total Ñ Ativo.: {inativas:#,##0.00}";
        LblTotalGeral.Text = $"Total Geral...: {(ativas + inativas):#,##0.00}";
    }

    private async void FrmCadFixos_Load(object sender, EventArgs e) { LblDataCadastro.Text = $"Data Cadastro: {DateTime.Now:dd/MM/yyyy}"; try { await CarregarClientesAsync(); } catch (Exception ex) { MessageBox.Show(ex.Message); } }
    private async void CbxCliente_SelectedIndexChanged(object sender, EventArgs e) { if (carregandoClientes || CbxCliente.SelectedValue is not int id) return; clienteId = id; LimparCampos(); await CarregarDespesasAsync(); }
    private async void BtnSalvar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Cadastrar);
    private async void BtnAlterar_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Atualizar);
    private async void BtnExcluir_Click(object sender, EventArgs e) => await ExecutarAsync(Operacao.Excluir);
    private async void FrmCadFixos_FormClosing(object sender, FormClosingEventArgs e) { if (frmPrincipal is not null) await frmPrincipal.AtualizarDadosAsync(); }

    private void DgvListarFixos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || DgvListarFixos.Rows[e.RowIndex].DataBoundItem is not DespesaFixaDto despesa) return;
        despesaId = despesa.Id; TxtDescricao.Text = despesa.Descricao; TxtValor.Text = despesa.Valor.ToString("#,##0.00"); MktDataInicio.Text = despesa.DataInicio.ToString("dd/MM/yyyy"); MktDataFim.Text = despesa.DataFim?.ToString("dd/MM/yyyy") ?? string.Empty; BtnAlterar.Enabled = true; BtnExcluir.Enabled = true; BtnSalvar.Enabled = false;
    }

    private void TxtValor_TextChanged(object sender, EventArgs e) { var validador = new ValidarNumero(); TxtValor.Text = validador.Validar(TxtValor.Text); TxtValor.Select(TxtValor.Text.Length, 0); }
    private void TxtValor_Leave(object sender, EventArgs e) { var validador = new ValidarNumero(); TxtValor.Text = validador.Formatar(validador.Zero(TxtValor.Text)); }
    private void TxtValor_Enter(object sender, EventArgs e) { if (TxtValor.Text == "0,00") TxtValor.Text = string.Empty; }

    private ListarClientesHandler GetListarClientesHandler() => listarClientesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private CadastrarDespesaFixaHandler GetCadastrarHandler() => cadastrarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private AtualizarDespesaFixaHandler GetAtualizarHandler() => atualizarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ExcluirDespesaFixaHandler GetExcluirHandler() => excluirHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarDespesasFixasPorClienteHandler GetListarHandler() => listarHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private enum Operacao { Cadastrar, Atualizar, Excluir }
}
