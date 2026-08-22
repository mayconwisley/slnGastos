using Gastos.Application.Clientes;
using Gastos.Application.DespesasFixas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmConFixos : Form
{
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly ListarDespesasFixasPorClienteHandler listarDespesasHandler;
    private bool carregandoClientes;

    public FrmConFixos()
    {
        InitializeComponent();
    }

    public FrmConFixos(ListarClientesHandler listarClientesHandler, ListarDespesasFixasPorClienteHandler listarDespesasHandler)
    {
        InitializeComponent();
        this.listarClientesHandler = listarClientesHandler;
        this.listarDespesasHandler = listarDespesasHandler;
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

    private async Task CarregarDespesasAsync(int clienteId)
    {
        var despesas = await GetListarDespesasHandler().HandleAsync(new ListarDespesasFixasPorClienteQuery(clienteId), CancellationToken.None);
        DgvListarFixos.DataSource = despesas;
        AtualizarTotais(despesas);
    }

    private void AtualizarTotais(IReadOnlyList<DespesaFixaDto> despesas)
    {
        var ativas = despesas.Where(item => item.Ativa).Sum(item => item.Valor);
        var inativas = despesas.Where(item => !item.Ativa).Sum(item => item.Valor);
        LblTotalAtivo.Text = $"Total Ativo...: {ativas:#,##0.00}";
        LblTotalNAtivo.Text = $"Total Ñ Ativo.: {inativas:#,##0.00}";
        LblTotalGeral.Text = $"Total Geral...: {(ativas + inativas):#,##0.00}";
    }

    private async void FrmConFixos_Load(object sender, EventArgs e)
    {
        try { await CarregarClientesAsync(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private async void CbxCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carregandoClientes || CbxCliente.SelectedValue is not int clienteId) return;
        try { await CarregarDespesasAsync(clienteId); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private ListarClientesHandler GetListarClientesHandler() => listarClientesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarDespesasFixasPorClienteHandler GetListarDespesasHandler() => listarDespesasHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
}
