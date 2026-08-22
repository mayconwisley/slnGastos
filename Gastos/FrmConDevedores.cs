using Gastos.Application.Clientes;
using Gastos.Application.Devedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmConDevedores : Form
{
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly ListarResumoDevedoresPorClienteHandler listarResumoHandler;
    private bool carregandoClientes;

    public FrmConDevedores()
    {
        InitializeComponent();
    }

    public FrmConDevedores(ListarClientesHandler listarClientesHandler, ListarResumoDevedoresPorClienteHandler listarResumoHandler)
    {
        InitializeComponent();
        this.listarClientesHandler = listarClientesHandler;
        this.listarResumoHandler = listarResumoHandler;
    }

    private async Task CarregarClientesAsync()
    {
        carregandoClientes = true;
        try
        {
            CbxNome.DisplayMember = nameof(ClienteDto.Nome);
            CbxNome.ValueMember = nameof(ClienteDto.Id);
            CbxNome.DataSource = await GetListarClientesHandler().HandleAsync(new ListarClientesQuery(), CancellationToken.None);
        }
        finally { carregandoClientes = false; }
    }

    private async Task CarregarResumoAsync(int clienteId)
    {
        var resumo = await GetListarResumoHandler().HandleAsync(new ListarResumoDevedoresPorClienteQuery(clienteId), CancellationToken.None);
        DgvListaDevedores.DataSource = resumo;
        AtualizarTotais(resumo);
    }

    private void AtualizarTotais(IReadOnlyList<ResumoDevedorDto> itens)
    {
        var recebidos = itens.Where(item => item.EstaRecebido).Sum(item => item.Valor);
        var pendentes = itens.Where(item => !item.EstaRecebido).Sum(item => item.Valor);
        LblTotalAtivo.Text = $"Total Recebido..: {recebidos:#,##0.00}";
        LblTotalNAtivo.Text = $"Total Ñ Recebido: {pendentes:#,##0.00}";
        LblTotalGeral.Text = $"Total Geral..: {(recebidos + pendentes):#,##0.00}";
    }

    private async void FrmConDevedores_Load(object sender, EventArgs e)
    {
        try { await CarregarClientesAsync(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private async void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carregandoClientes || CbxNome.SelectedValue is not int clienteId) return;
        try { await CarregarResumoAsync(clienteId); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private ListarClientesHandler GetListarClientesHandler() => listarClientesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarResumoDevedoresPorClienteHandler GetListarResumoHandler() => listarResumoHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
}
