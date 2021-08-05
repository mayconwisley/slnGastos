using Negocio.Cliente.Listar;
using Negocio.Devedores.Listar;
using System;
using System.Windows.Forms;

namespace Gastos
{
    public partial class FrmConDevedores : Form
    {
        int idCliente;
        public FrmConDevedores()
        {
            InitializeComponent();
        }
        private void ListaCliente()
        {
            IdNomeCliente idNomeCliente = new IdNomeCliente();
            CbxNome.DataSource = idNomeCliente.Consulta();
        }
        private void ListaDevedores(int idCliente)
        {
            CadastroDevedoresCliente cadastroDevedoresCliente = new CadastroDevedoresCliente();
            DgvListaDevedores.DataSource = cadastroDevedoresCliente.Consulta(idCliente);
            Informacao();

        }
        private void Informacao()
        {
            decimal valTotalAtivo = 0, valTotalNAtivo = 0, valTotalGeral = 0;
            foreach (DataGridViewRow row in DgvListaDevedores.Rows)
            {
                if (row.Cells["Ativo"].Value.ToString() == "Sim")
                {
                    valTotalAtivo += decimal.Parse(row.Cells["Valor"].Value.ToString());
                }
                else
                {
                    valTotalNAtivo += decimal.Parse(row.Cells["Valor"].Value.ToString());
                }
                valTotalGeral += decimal.Parse(row.Cells["Valor"].Value.ToString());
            }

            LblTotalAtivo.Text = "Total Ativo..: " + valTotalAtivo.ToString("#,##0.00");
            LblTotalNAtivo.Text = "Total Ñ Ativo: " + valTotalNAtivo.ToString("#,##0.00");
            LblTotalGeral.Text = "Total Geral..: " + valTotalGeral.ToString("#,##0.00");
        }
        private void FrmConDevedores_Load(object sender, EventArgs e)
        {
            ListaCliente();
        }

        private void CbxNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            idCliente = int.Parse(CbxNome.SelectedValue.ToString());
            ListaDevedores(idCliente);
        }
    }
}
