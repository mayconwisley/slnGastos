using System;
using System.Threading;
using System.Windows.Forms;
using Gastos.Application;
using Gastos.Application.Clientes;
using Gastos.Application.Competencias;
using Gastos.Application.DespesasFixas;
using Gastos.Application.Emprestimos;
using Gastos.Application.Devedores;
using Gastos.Application.Movimentacoes;
using Gastos.Application.Painel;
using Gastos.Application.Usuarios;
using Gastos.Infrastructure;
using Gastos.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Gastos
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            string databasePath = LocalDatabase.EnsureCreated();
            using ServiceProvider serviceProvider = ConfigureServices(databasePath);
            serviceProvider.GetRequiredService<DatabaseInitializer>()
                .InitializeAsync(CancellationToken.None)
                .GetAwaiter()
                .GetResult();

            using FrmTelaLogin frmTelaLogin = new(
                serviceProvider.GetRequiredService<QuantidadeUsuariosHandler>(),
                serviceProvider.GetRequiredService<AutenticarUsuarioHandler>(),
                serviceProvider.GetRequiredService<ObterLembreteSenhaHandler>(),
                serviceProvider.GetRequiredService<CadastrarUsuarioHandler>(),
                serviceProvider.GetRequiredService<AtualizarUsuarioHandler>(),
                serviceProvider.GetRequiredService<ExcluirUsuarioHandler>(),
                serviceProvider.GetRequiredService<ListarUsuariosHandler>());

            if (frmTelaLogin.ShowDialog() == DialogResult.OK)
            {
                System.Windows.Forms.Application.Run(new FrmPrincipal(frmTelaLogin.Login, CriarDependencias(serviceProvider)));
            }
        }

        private static ServiceProvider ConfigureServices(string databasePath)
        {
            return new ServiceCollection()
                .AddApplication()
                .AddInfrastructure($"Data Source={databasePath};Foreign Keys=True")
                .BuildServiceProvider(validateScopes: true);
        }

        private static FrmPrincipalDependencies CriarDependencias(IServiceProvider services) => new()
        {
            CadastrarCliente = services.GetRequiredService<CadastrarClienteHandler>(),
            AtualizarCliente = services.GetRequiredService<AtualizarClienteHandler>(),
            ExcluirCliente = services.GetRequiredService<ExcluirClienteHandler>(),
            ListarClientes = services.GetRequiredService<ListarClientesHandler>(),
            CadastrarCompetencia = services.GetRequiredService<CadastrarCompetenciaHandler>(),
            AtualizarCompetencia = services.GetRequiredService<AtualizarCompetenciaHandler>(),
            ExcluirCompetencia = services.GetRequiredService<ExcluirCompetenciaHandler>(),
            ListarCompetencias = services.GetRequiredService<ListarCompetenciasPorClienteHandler>(),
            CadastrarDespesaFixa = services.GetRequiredService<CadastrarDespesaFixaHandler>(),
            AtualizarDespesaFixa = services.GetRequiredService<AtualizarDespesaFixaHandler>(),
            ExcluirDespesaFixa = services.GetRequiredService<ExcluirDespesaFixaHandler>(),
            ListarDespesasFixas = services.GetRequiredService<ListarDespesasFixasPorClienteHandler>(),
            CadastrarEmprestimo = services.GetRequiredService<CadastrarEmprestimoHandler>(),
            AtualizarEmprestimo = services.GetRequiredService<AtualizarEmprestimoHandler>(),
            ExcluirEmprestimo = services.GetRequiredService<ExcluirEmprestimoHandler>(),
            GerarParcelasEmprestimo = services.GetRequiredService<GerarParcelasEmprestimoHandler>(),
            ListarEmprestimos = services.GetRequiredService<ListarEmprestimosPorClienteHandler>(),
            CadastrarDevedor = services.GetRequiredService<CadastrarDevedorHandler>(),
            AtualizarDevedor = services.GetRequiredService<AtualizarDevedorHandler>(),
            ExcluirDevedor = services.GetRequiredService<ExcluirDevedorHandler>(),
            GerarParcelasDevedor = services.GetRequiredService<GerarParcelasDevedorHandler>(),
            ListarDevedores = services.GetRequiredService<ListarDevedoresPorClienteHandler>(),
            ListarResumoDevedores = services.GetRequiredService<ListarResumoDevedoresPorClienteHandler>(),
            CadastrarMovimentacao = services.GetRequiredService<CadastrarMovimentacaoHandler>(),
            AtualizarMovimentacao = services.GetRequiredService<AtualizarMovimentacaoHandler>(),
            ExcluirMovimentacao = services.GetRequiredService<ExcluirMovimentacaoHandler>(),
            ListarMovimentacoes = services.GetRequiredService<ListarMovimentacoesPorCompetenciaHandler>(),
            CadastrarParcelaEmprestimo = services.GetRequiredService<CadastrarParcelaEmprestimoHandler>(),
            AtualizarParcelaEmprestimo = services.GetRequiredService<AtualizarParcelaEmprestimoHandler>(),
            ExcluirParcelaEmprestimo = services.GetRequiredService<ExcluirParcelaEmprestimoHandler>(),
            ExcluirParcelasEmprestimo = services.GetRequiredService<ExcluirParcelasEmprestimoHandler>(),
            QuitarEmprestimo = services.GetRequiredService<QuitarEmprestimoHandler>(),
            ListarParcelasEmprestimo = services.GetRequiredService<ListarParcelasEmprestimoHandler>(),
            CadastrarParcelaDevedor = services.GetRequiredService<CadastrarParcelaDevedorHandler>(),
            AtualizarParcelaDevedor = services.GetRequiredService<AtualizarParcelaDevedorHandler>(),
            ExcluirParcelaDevedor = services.GetRequiredService<ExcluirParcelaDevedorHandler>(),
            ExcluirParcelasDevedor = services.GetRequiredService<ExcluirParcelasDevedorHandler>(),
            ListarParcelasDevedor = services.GetRequiredService<ListarParcelasDevedorHandler>(),
            ObterResumoPainel = services.GetRequiredService<ObterResumoPainelHandler>(),
            CadastrarUsuario = services.GetRequiredService<CadastrarUsuarioHandler>(),
            AtualizarUsuario = services.GetRequiredService<AtualizarUsuarioHandler>(),
            ExcluirUsuario = services.GetRequiredService<ExcluirUsuarioHandler>(),
            ListarUsuarios = services.GetRequiredService<ListarUsuariosHandler>()
        };
    }
}
