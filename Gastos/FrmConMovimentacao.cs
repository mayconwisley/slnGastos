using Negocio.Cliente.Listar;
using Negocio.Competencia.Listar;
using Negocio.Movimento.Geral.Listar;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gastos;

public partial class FrmConMovimentacao : Form
{
    int idCliente, idCompetencia, idComeptenciaAnterior;
    decimal valSalEntSaiAnt = 0, valSalPagRecAnt = 0, valSalPendAnte = 0;
    DateTime data;
    public FrmConMovimentacao()
    {
        InitializeComponent();
    }

    private void CbxNome_SelectedIndexChanged(object sender, EventArgs e)

    {
        idCliente = int.Parse(CbxNome.SelectedValue.ToString());

       
        bool sucesso = DateTime.TryParse(MktCompetencia.Text.Trim(), out data);
        if (sucesso)
        {
            ListarIdCompetencia(idCliente, data);
        }
        InformacaoSaldoAnterior(idCliente, idComeptenciaAnterior);
        ListarMovimentacao(idCliente, idCompetencia);
    }

    private void ListarIdCompetencia(int idCliente, DateTime data)
    {
        CompetenciaIdData competenciaIdData = new CompetenciaIdData();
        idCompetencia = competenciaIdData.CompetenciaId(idCliente, data);
        idComeptenciaAnterior = competenciaIdData.CompetenciaId(idCliente, data.AddMonths(-1));
    }

    private void ListarCliente()
    {
        IdNomeCliente idNomeCliente = new IdNomeCliente();
        CbxNome.DataSource = idNomeCliente.Consulta();
    }

    private void MktCompetencia_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            CbxNome_SelectedIndexChanged(e, e);
        }
    }

    private void MktCompetencia_Leave(object sender, EventArgs e)
    {
        CbxNome_SelectedIndexChanged(e, e);
    }

    private void ListarMovimentacao(int idCliente, int idCompetencia)
    {
        CadastroMovGeralCliente cadastroMovGeralCliente = new CadastroMovGeralCliente();
        DgvListaMovimentacao.DataSource = cadastroMovGeralCliente.Consulta(idCliente, idCompetencia);
        Informacoes();
    }
    private void InformacaoSaldoAnterior(int idCliente, int idCompetencia)
    {
        SaldoEntSaiClienteComp saldoEntSaiClienteComp = new SaldoEntSaiClienteComp();
        SaldoPagRecClienteComp saldoPagRecClienteComp = new SaldoPagRecClienteComp();
        SaldoPendClienteComp saldoPendClienteComp = new SaldoPendClienteComp();

        valSalEntSaiAnt = saldoEntSaiClienteComp.Saldo(idCliente, idCompetencia);
        valSalPagRecAnt = saldoPagRecClienteComp.Saldo(idCliente, idCompetencia, data);
        valSalPendAnte = saldoPendClienteComp.Saldo(idCliente, idCompetencia);

        if (valSalEntSaiAnt == 0)
        {
            LblSalES.ForeColor = Color.Black;
        }
        else if (valSalEntSaiAnt < 0)
        {
            LblSalES.ForeColor = Color.Red;
        }
        else
        {
            LblSalES.ForeColor = Color.Green;
        }

        if (valSalPagRecAnt == 0)
        {
            LblSalPR.ForeColor = Color.Black;
        }
        else if (valSalPagRecAnt < 0)
        {
            LblSalPR.ForeColor = Color.Red;
        }
        else
        {
            LblSalPR.ForeColor = Color.Green;
        }

        if (valSalPendAnte == 0)
        {
            LblSalPend.ForeColor = Color.Black;
        }
        else if (valSalPendAnte < 0)
        {
            LblSalPend.ForeColor = Color.Red;
        }
        else
        {
            LblSalPend.ForeColor = Color.Green;
        }

        LblSalES.Text = "Sal. E. S.: " + valSalEntSaiAnt.ToString("#,##0.00");
        LblSalPR.Text = "Sal. P. R.: " + valSalPagRecAnt.ToString("#,##0.00");
        LblSalPend.Text = "Sal. Pend.: " + valSalPendAnte.ToString("#,##0.00");
    }

    private void Informacoes()
    {
        decimal valEntrda = 0, valSaida = 0, valSaldo = 0, valPago = 0, valRecebido = 0, valSaldo0 = 0;
        decimal valPendenciaEntrada = 0, valPendenciaSaida = 0, valPendenciaSaldo = 0;
        string strTipoLancamento, strTipoPagoRecebido;

        foreach (DataGridViewRow row in DgvListaMovimentacao.Rows)
        {
            strTipoLancamento = row.Cells["TipoLancamento"].Value.ToString();
            strTipoPagoRecebido = row.Cells["TipoPagoRecebido"].Value.ToString();

            if (strTipoLancamento == "Entrada")
            {
                valEntrda += decimal.Parse(row.Cells["Valor"].Value.ToString());
            }
            else
            {
                valSaida += decimal.Parse(row.Cells["Valor"].Value.ToString());
            }

            valSaldo = valEntrda - valSaida;

            if (strTipoPagoRecebido == "Pago")
            {
                valPago += decimal.Parse(row.Cells["Valor"].Value.ToString());
            }
            else if (strTipoPagoRecebido == "Recebido")
            {
                valRecebido += decimal.Parse(row.Cells["Valor"].Value.ToString());
            }

            valSaldo0 = valRecebido - valPago;

            if (strTipoLancamento == "Entrada" && strTipoPagoRecebido == "Pendente")
            {
                valPendenciaEntrada += decimal.Parse(row.Cells["Valor"].Value.ToString());
            }
            else if (strTipoLancamento == "Saída" && strTipoPagoRecebido == "Pendente")
            {
                valPendenciaSaida += decimal.Parse(row.Cells["Valor"].Value.ToString());
            }
            valPendenciaSaldo = valPendenciaEntrada - valPendenciaSaida;
        }

        valSaldo += valSalEntSaiAnt;
        valSaldo0 += valSalPagRecAnt;
        valPendenciaSaldo += valSalPendAnte;

        #region Mudar cor do saldo

        if (valSaldo == 0)
        {
            LblSaldo.ForeColor = Color.Black;
        }
        else if (valSaldo < 0)
        {
            LblSaldo.ForeColor = Color.Red;
        }
        else
        {
            LblSaldo.ForeColor = Color.Green;
        }

        if (valSaldo0 == 0)
        {
            LblSaldo0.ForeColor = Color.Black;
        }
        else if (valSaldo0 < 0)
        {
            LblSaldo0.ForeColor = Color.Red;
        }
        else
        {
            LblSaldo0.ForeColor = Color.Green;
        }

        if (valPendenciaSaldo == 0)
        {
            LblSalPen.ForeColor = Color.Black;
        }
        else if (valPendenciaSaldo < 0)
        {
            LblSalPen.ForeColor = Color.Red;
        }
        else
        {
            LblSalPen.ForeColor = Color.Green;
        }
        #endregion

        LblValorEntrada.Text = "Valor Entrada: " + valEntrda.ToString("#,##0.00");
        LblValorSaida.Text = "Valor Saída..: " + valSaida.ToString("#,##0.00");
        LblSaldo.Text = "Valor Saldo..: " + valSaldo.ToString("#,##0.00");

        LblValorPago.Text = "Valor Pago....: " + valPago.ToString("#,##0.00");
        LblValorRecebido.Text = "Valor Recebido: " + valRecebido.ToString("#,##0.00");
        LblSaldo0.Text = "Valor Saldo...: " + valSaldo0.ToString("#,##0.00");

        LblValPenEnt.Text = "Valor Pendente Entrada: " + valPendenciaEntrada.ToString("#,##0.00");
        LblValPenSai.Text = "Valor Pendente Saída..: " + valPendenciaSaida.ToString("#,##0.00");
        LblSalPen.Text = "Valor Saldo...........: " + valPendenciaSaldo.ToString("#,##0.00");
    }

    private void FrmConMovimentacao_Load(object sender, EventArgs e)
    {
        MktCompetencia.Text = DateTime.Now.ToString("MM/yyyy");
        ListarCliente();
        Informacoes();
    }
}
