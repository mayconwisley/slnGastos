using Gastos.Application.Clientes;
using Gastos.Application.Competencias;
using Gastos.Application.DespesasFixas;
using Gastos.Application.Emprestimos;
using Gastos.Application.Devedores;
using Gastos.Application.Movimentacoes;
using Gastos.Application.Painel;
using Gastos.Application.Usuarios;
using Microsoft.Extensions.DependencyInjection;

namespace Gastos.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<CadastrarClienteHandler>();
        services.AddTransient<AtualizarClienteHandler>();
        services.AddTransient<ExcluirClienteHandler>();
        services.AddTransient<ListarClientesHandler>();
        services.AddTransient<CadastrarCompetenciaHandler>();
        services.AddTransient<AtualizarCompetenciaHandler>();
        services.AddTransient<ExcluirCompetenciaHandler>();
        services.AddTransient<ListarCompetenciasPorClienteHandler>();
        services.AddTransient<CadastrarDespesaFixaHandler>();
        services.AddTransient<AtualizarDespesaFixaHandler>();
        services.AddTransient<ExcluirDespesaFixaHandler>();
        services.AddTransient<ListarDespesasFixasPorClienteHandler>();
        services.AddTransient<CadastrarEmprestimoHandler>();
        services.AddTransient<AtualizarEmprestimoHandler>();
        services.AddTransient<ExcluirEmprestimoHandler>();
        services.AddTransient<GerarParcelasEmprestimoHandler>();
        services.AddTransient<ListarEmprestimosPorClienteHandler>();
        services.AddTransient<CadastrarParcelaEmprestimoHandler>();
        services.AddTransient<AtualizarParcelaEmprestimoHandler>();
        services.AddTransient<ExcluirParcelaEmprestimoHandler>();
        services.AddTransient<QuitarEmprestimoHandler>();
        services.AddTransient<ExcluirParcelasEmprestimoHandler>();
        services.AddTransient<ListarParcelasEmprestimoHandler>();
        services.AddTransient<CadastrarDevedorHandler>();
        services.AddTransient<AtualizarDevedorHandler>();
        services.AddTransient<ExcluirDevedorHandler>();
        services.AddTransient<GerarParcelasDevedorHandler>();
        services.AddTransient<ListarDevedoresPorClienteHandler>();
        services.AddTransient<ListarResumoDevedoresPorClienteHandler>();
        services.AddTransient<CadastrarParcelaDevedorHandler>();
        services.AddTransient<AtualizarParcelaDevedorHandler>();
        services.AddTransient<ExcluirParcelaDevedorHandler>();
        services.AddTransient<ExcluirParcelasDevedorHandler>();
        services.AddTransient<ListarParcelasDevedorHandler>();
        services.AddTransient<CadastrarMovimentacaoHandler>();
        services.AddTransient<AtualizarMovimentacaoHandler>();
        services.AddTransient<ExcluirMovimentacaoHandler>();
        services.AddTransient<ListarMovimentacoesPorCompetenciaHandler>();
        services.AddTransient<ObterResumoPainelHandler>();
        services.AddTransient<CadastrarUsuarioHandler>();
        services.AddTransient<AtualizarUsuarioHandler>();
        services.AddTransient<ExcluirUsuarioHandler>();
        services.AddTransient<ListarUsuariosHandler>();
        services.AddTransient<QuantidadeUsuariosHandler>();
        services.AddTransient<AutenticarUsuarioHandler>();
        services.AddTransient<ObterLembreteSenhaHandler>();

        return services;
    }
}
