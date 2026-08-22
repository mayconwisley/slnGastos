using Gastos.Application.Clientes;
using Gastos.Application.Emprestimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmConEmprestimo : Form
{
    private readonly ListarClientesHandler listarClientesHandler;
    private readonly ListarEmprestimosPorClienteHandler listarEmprestimosHandler;
    private bool carregandoClientes;

    public FrmConEmprestimo()
    {
        InitializeComponent();
    }

    public FrmConEmprestimo(ListarClientesHandler listarClientesHandler, ListarEmprestimosPorClienteHandler listarEmprestimosHandler)
    {
        InitializeComponent();
        this.listarClientesHandler = listarClientesHandler;
        this.listarEmprestimosHandler = listarEmprestimosHandler;
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

    private async Task CarregarEmprestimosAsync(int clienteId)
    {
        var emprestimos = await GetListarEmprestimosHandler().HandleAsync(new ListarEmprestimosPorClienteQuery(clienteId), CancellationToken.None);
        DgvListaEmprestimos.DataSource = emprestimos;
        AtualizarTotais(emprestimos);
    }

    private void AtualizarTotais(IReadOnlyList<EmprestimoDto> emprestimos)
    {
        var ativos = emprestimos.Where(item => item.Ativo).Sum(item => item.ValorParcela);
        var inativos = emprestimos.Where(item => !item.Ativo).Sum(item => item.ValorParcela);
        LblTotalAtivo.Text = $"Total Ativo..: {ativos:#,##0.00}";
        LblTotalNAtivo.Text = $"Total Ñ Ativo: {inativos:#,##0.00}";
        LblTotalGeral.Text = $"Total Geral..: {(ativos + inativos):#,##0.00}";
    }

    private async void FrmConEmprestimo_Load(object sender, EventArgs e)
    {
        try { await CarregarClientesAsync(); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private async void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (carregandoClientes || CbxNome.SelectedValue is not int clienteId) return;
        try { await CarregarEmprestimosAsync(clienteId); } catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    private ListarClientesHandler GetListarClientesHandler() => listarClientesHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
    private ListarEmprestimosPorClienteHandler GetListarEmprestimosHandler() => listarEmprestimosHandler ?? throw new InvalidOperationException("O formulário deve ser criado pelo contêiner de DI.");
}
