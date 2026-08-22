namespace Gastos.Domain.Movimentacoes;
public enum TipoLancamento { Entrada, Saida }
public enum SituacaoFinanceira { Pendente, Pago, Recebido }
public enum MeioMonetario { Dinheiro, Cheque }
public enum OrigemMovimentacao { Manual, IntegradoFixos, IntegradoEmprestimos, IntegradoDevedores }
