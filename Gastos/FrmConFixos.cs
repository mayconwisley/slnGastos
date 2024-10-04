using Negocio.Cliente.Listar;
using Negocio.Fixo.Listar;
using System;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmConFixos : Form
{
    int idCliente;
    public FrmConFixos()
    {
        InitializeComponent();
    }

    private void ListarCliente()
    {
        IdNomeCliente idNomeCliente = new IdNomeCliente();
        CbxCliente.DataSource = idNomeCliente.Consulta();
    }
    private void ListaFixo(int idCliente)
    {
        CadastroFixosCliente cadastroFixosCliente = new CadastroFixosCliente();
        DgvListarFixos.DataSource = cadastroFixosCliente.Consulta(idCliente);
        Informacoes();
    }
    private void Informacoes()
    {
        decimal valTotalAtivo = 0, valTotalNAtivo = 0, valTotalGeral = 0;

        foreach (DataGridViewRow row in DgvListarFixos.Rows)
        {
            if (row.Cells["Ativo"].Value.ToString() == "Sim")
            {
                valTotalAtivo = valTotalAtivo + decimal.Parse(row.Cells["Valor"].Value.ToString());
            }
            else
            {
                valTotalNAtivo = valTotalNAtivo + decimal.Parse(row.Cells["Valor"].Value.ToString());
            }

            valTotalGeral = valTotalGeral + decimal.Parse(row.Cells["Valor"].Value.ToString());
        }

        LblTotalAtivo.Text = "Total Ativo...: " + valTotalAtivo.ToString("#,##0.00");
        LblTotalNAtivo.Text = "Total Ñ Ativo.: " + valTotalNAtivo.ToString("#,##0.00");
        LblTotalGeral.Text = "Total Geral...: " + valTotalGeral.ToString("#,##0.00");
    }
    private void FrmConFixos_Load(object sender, EventArgs e)
    {
        ListarCliente();
    }

    private void CbxCliente_SelectedIndexChanged(object sender, EventArgs e)
    {
        idCliente = int.Parse(CbxCliente.SelectedValue.ToString());
        ListaFixo(idCliente);
    }
}
