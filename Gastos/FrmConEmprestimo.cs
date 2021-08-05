using Negocio.Cliente.Listar;
using Negocio.Emprestimos.Listar;
using System;
using System.Windows.Forms;

namespace Gastos
{
    public partial class FrmConEmprestimo : Form
    {
        int idCliente;

        public FrmConEmprestimo()
        {
            InitializeComponent();
        }
        private void ListaCliente()
        {
            IdNomeCliente idNomeCliente = new IdNomeCliente();
            CbxNome.DataSource = idNomeCliente.Consulta();
        }
        private void ListaEmprestimos(int idCliente)
        {
            CadastroEmprestimosCliente cadastroEmprestimosCliente = new CadastroEmprestimosCliente();
            DgvListaEmprestimos.DataSource = cadastroEmprestimosCliente.Consulta(idCliente);
            Informacao();

        }

        private void Informacao()
        {
            decimal valTotalAtivo = 0, valTotalNAtivo = 0, valTotalGeral = 0;
            foreach (DataGridViewRow row in DgvListaEmprestimos.Rows)
            {
                if (row.Cells["Ativo"].Value.ToString() == "Sim")
                {
                    valTotalAtivo += decimal.Parse(row.Cells["ValorParcela"].Value.ToString());
                }
                else
                {
                    valTotalNAtivo += decimal.Parse(row.Cells["ValorParcela"].Value.ToString());
                }
                valTotalGeral += decimal.Parse(row.Cells["ValorParcela"].Value.ToString());
            }

            LblTotalAtivo.Text = "Total Ativo..: " + valTotalAtivo.ToString("#,##0.00");
            LblTotalNAtivo.Text = "Total Ñ Ativo: " + valTotalNAtivo.ToString("#,##0.00");
            LblTotalGeral.Text = "Total Geral..: " + valTotalGeral.ToString("#,##0.00");
        }

        private void FrmConEmprestimo_Load(object sender, EventArgs e)
        {
            ListaCliente();
        }

        private void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCliente = int.Parse(CbxNome.SelectedValue.ToString());
            ListaEmprestimos(idCliente);
        }
    }
}
