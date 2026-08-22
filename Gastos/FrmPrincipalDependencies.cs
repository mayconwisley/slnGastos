using Gastos.Application.Clientes;
using Gastos.Application.Competencias;
using Gastos.Application.Devedores;
using Gastos.Application.DespesasFixas;
using Gastos.Application.Emprestimos;
using Gastos.Application.Movimentacoes;
using Gastos.Application.Painel;
using Gastos.Application.Usuarios;

namespace Gastos;

public sealed class FrmPrincipalDependencies
{
    public required CadastrarClienteHandler CadastrarCliente { get; init; }
    public required AtualizarClienteHandler AtualizarCliente { get; init; }
    public required ExcluirClienteHandler ExcluirCliente { get; init; }
    public required ListarClientesHandler ListarClientes { get; init; }
    public required CadastrarCompetenciaHandler CadastrarCompetencia { get; init; }
    public required AtualizarCompetenciaHandler AtualizarCompetencia { get; init; }
    public required ExcluirCompetenciaHandler ExcluirCompetencia { get; init; }
    public required ListarCompetenciasPorClienteHandler ListarCompetencias { get; init; }
    public required CadastrarDespesaFixaHandler CadastrarDespesaFixa { get; init; }
    public required AtualizarDespesaFixaHandler AtualizarDespesaFixa { get; init; }
    public required ExcluirDespesaFixaHandler ExcluirDespesaFixa { get; init; }
    public required ListarDespesasFixasPorClienteHandler ListarDespesasFixas { get; init; }
    public required CadastrarEmprestimoHandler CadastrarEmprestimo { get; init; }
    public required AtualizarEmprestimoHandler AtualizarEmprestimo { get; init; }
    public required ExcluirEmprestimoHandler ExcluirEmprestimo { get; init; }
    public required GerarParcelasEmprestimoHandler GerarParcelasEmprestimo { get; init; }
    public required ListarEmprestimosPorClienteHandler ListarEmprestimos { get; init; }
    public required CadastrarDevedorHandler CadastrarDevedor { get; init; }
    public required AtualizarDevedorHandler AtualizarDevedor { get; init; }
    public required ExcluirDevedorHandler ExcluirDevedor { get; init; }
    public required GerarParcelasDevedorHandler GerarParcelasDevedor { get; init; }
    public required ListarDevedoresPorClienteHandler ListarDevedores { get; init; }
    public required ListarResumoDevedoresPorClienteHandler ListarResumoDevedores { get; init; }
    public required CadastrarMovimentacaoHandler CadastrarMovimentacao { get; init; }
    public required AtualizarMovimentacaoHandler AtualizarMovimentacao { get; init; }
    public required ExcluirMovimentacaoHandler ExcluirMovimentacao { get; init; }
    public required ListarMovimentacoesPorCompetenciaHandler ListarMovimentacoes { get; init; }
    public required CadastrarParcelaEmprestimoHandler CadastrarParcelaEmprestimo { get; init; }
    public required AtualizarParcelaEmprestimoHandler AtualizarParcelaEmprestimo { get; init; }
    public required ExcluirParcelaEmprestimoHandler ExcluirParcelaEmprestimo { get; init; }
    public required ExcluirParcelasEmprestimoHandler ExcluirParcelasEmprestimo { get; init; }
    public required QuitarEmprestimoHandler QuitarEmprestimo { get; init; }
    public required ListarParcelasEmprestimoHandler ListarParcelasEmprestimo { get; init; }
    public required CadastrarParcelaDevedorHandler CadastrarParcelaDevedor { get; init; }
    public required AtualizarParcelaDevedorHandler AtualizarParcelaDevedor { get; init; }
    public required ExcluirParcelaDevedorHandler ExcluirParcelaDevedor { get; init; }
    public required ExcluirParcelasDevedorHandler ExcluirParcelasDevedor { get; init; }
    public required ListarParcelasDevedorHandler ListarParcelasDevedor { get; init; }
    public required ObterResumoPainelHandler ObterResumoPainel { get; init; }
    public required CadastrarUsuarioHandler CadastrarUsuario { get; init; }
    public required AtualizarUsuarioHandler AtualizarUsuario { get; init; }
    public required ExcluirUsuarioHandler ExcluirUsuario { get; init; }
    public required ListarUsuariosHandler ListarUsuarios { get; init; }
}
