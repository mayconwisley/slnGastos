using System.Windows;
using Gastos.Application;
using Gastos.Application.Usuarios;
using Gastos.Infrastructure;
using Gastos.Infrastructure.Persistence;
using Gastos.Presentation.Servicos;
using Gastos.Presentation.ViewModels;
using Gastos.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Gastos;

public partial class App : System.Windows.Application
{
    private ServiceProvider? serviceProvider;

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        ShutdownMode = ShutdownMode.OnExplicitShutdown;

        try
        {
            string databasePath = LocalDatabase.EnsureCreated();
            serviceProvider = ConfigurarServicos(databasePath);
            serviceProvider.GetRequiredService<ServicoTema>().Inicializar();
            await serviceProvider.GetRequiredService<DatabaseInitializer>().InitializeAsync(CancellationToken.None);

            var quantidadeUsuariosHandler = serviceProvider.GetRequiredService<QuantidadeUsuariosHandler>();
            if (await quantidadeUsuariosHandler.HandleAsync(CancellationToken.None) == 0)
            {
                var cadastroInicialWindow = serviceProvider.GetRequiredService<CadastroInicialUsuarioWindow>();
                if (cadastroInicialWindow.ShowDialog() != true)
                {
                    Shutdown();
                    return;
                }
            }

            var loginWindow = serviceProvider.GetRequiredService<LoginWindow>();
            bool autenticado = loginWindow.ShowDialog() == true;
            if (!autenticado)
            {
                Shutdown();
                return;
            }

            var janelaPrincipal = serviceProvider.GetRequiredService<MainWindow>();
            MainWindow = janelaPrincipal;
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            janelaPrincipal.Show();
            janelaPrincipal.Activate();
        }
        catch (Exception exception)
        {
            MessageBox.Show(
                $"Não foi possível iniciar a aplicação. {exception.Message}",
                "Controle de Gastos",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            Shutdown(-1);
        }
    }

    protected override void OnExit(ExitEventArgs e)
    {
        serviceProvider?.Dispose();
        base.OnExit(e);
    }

    private static ServiceProvider ConfigurarServicos(string databasePath)
    {
        return new ServiceCollection()
            .AddApplication()
            .AddInfrastructure($"Data Source={databasePath};Foreign Keys=True")
            .AddPresentation()
            .BuildServiceProvider(validateScopes: true);
    }
}
