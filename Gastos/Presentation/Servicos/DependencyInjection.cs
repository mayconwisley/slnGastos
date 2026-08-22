using Gastos.Presentation.ViewModels;
using Gastos.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Gastos.Presentation.Servicos;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddSingleton<ContextoSessao>();
        services.AddSingleton<ServicoTema>();
        services.AddSingleton<FabricaPagina>();
        services.AddSingleton<ShellViewModel>();
        services.AddTransient<LoginViewModel>();
        services.AddTransient<CadastroInicialUsuarioViewModel>();
        services.AddTransient<PainelViewModel>();
        services.AddTransient<ClientesViewModel>();
        services.AddTransient<CompetenciasViewModel>();
        services.AddTransient<UsuariosViewModel>();
        services.AddTransient<DespesasFixasViewModel>();
        services.AddTransient<MovimentacoesViewModel>();
        services.AddTransient<EmprestimosViewModel>();
        services.AddTransient<DevedoresViewModel>();
        services.AddTransient<ParcelasEmprestimoViewModel>();
        services.AddTransient<ParcelasDevedorViewModel>();
        services.AddTransient<LoginWindow>();
        services.AddTransient<CadastroInicialUsuarioWindow>();
        services.AddSingleton<MainWindow>();

        return services;
    }
}
