using System.Windows;
using System.Windows.Threading;
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
        SplashWindow? splashWindow = null;

        try
        {
            splashWindow = new SplashWindow();
            splashWindow.Show();
            await Dispatcher.Yield(DispatcherPriority.Render);

            splashWindow.AtualizarStatus("Preparando armazenamento local...");
            string databasePath = LocalDatabase.EnsureCreated();

            splashWindow.AtualizarStatus("Configurando serviços da aplicação...");
            serviceProvider = ConfigurarServicos(databasePath);

            splashWindow.AtualizarStatus("Aplicando preferências de interface...");
            serviceProvider.GetRequiredService<ServicoTema>().Inicializar();

            splashWindow.AtualizarStatus("Verificando atualizações do banco de dados...");
            await serviceProvider.GetRequiredService<DatabaseInitializer>().InitializeAsync(CancellationToken.None);

            splashWindow.AtualizarStatus("Validando acesso ao sistema...");
            var quantidadeUsuariosHandler = serviceProvider.GetRequiredService<QuantidadeUsuariosHandler>();
            int quantidadeUsuarios = await quantidadeUsuariosHandler.HandleAsync(CancellationToken.None);

            FecharSplash(splashWindow);

            if (quantidadeUsuarios == 0)
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
            FecharSplash(splashWindow);
            MessageBox.Show(
                $"Não foi possível iniciar a aplicação. {exception.Message}",
                "Finora — Controle de Gastos",
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

    private static void FecharSplash(SplashWindow? splashWindow)
    {
        if (splashWindow?.IsVisible == true)
        {
            splashWindow.Close();
        }
    }
}
