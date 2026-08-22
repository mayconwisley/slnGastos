using Microsoft.Win32;
using System.Windows;
using System.Windows.Threading;

namespace Gastos.Presentation.Servicos;

public sealed class ServicoTema : IDisposable
{
    private const string TemaClaro = "Themes/Theme.Light.xaml";
    private const string TemaEscuro = "Themes/Theme.Dark.xaml";
    private const string ChaveTemaWindows = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";
    private const string NomeValorTemaWindows = "AppsUseLightTheme";
    private bool inicializado;

    public PreferenciaTema Preferencia { get; private set; } = PreferenciaTema.Automatico;

    public bool EstaEscuro { get; private set; }

    public event EventHandler? TemaAlterado;

    public void Inicializar()
    {
        if (inicializado)
        {
            return;
        }

        inicializado = true;
        if (OperatingSystem.IsWindows())
        {
            SystemEvents.UserPreferenceChanged += AoAlterarPreferenciaDoUsuario;
        }

        AtualizarTema(forcarAplicacao: true);
    }

    public void DefinirPreferencia(PreferenciaTema preferencia)
    {
        if (Preferencia == preferencia)
        {
            return;
        }

        Preferencia = preferencia;
        AtualizarTema(forcarAplicacao: true);
    }

    public void Dispose()
    {
        if (!inicializado)
        {
            return;
        }

        if (OperatingSystem.IsWindows())
        {
            SystemEvents.UserPreferenceChanged -= AoAlterarPreferenciaDoUsuario;
        }

        inicializado = false;
    }

    private void AoAlterarPreferenciaDoUsuario(object? sender, UserPreferenceChangedEventArgs e)
    {
        if (Preferencia != PreferenciaTema.Automatico)
        {
            return;
        }

        var dispatcher = System.Windows.Application.Current?.Dispatcher;
        if (dispatcher is null || dispatcher.HasShutdownStarted || dispatcher.HasShutdownFinished)
        {
            return;
        }

        _ = dispatcher.BeginInvoke(DispatcherPriority.Normal, AtualizarTemaAutomatico);
    }

    private void AtualizarTemaAutomatico()
    {
        AtualizarTema(forcarAplicacao: false);
    }

    private void AtualizarTema(bool forcarAplicacao)
    {
        bool deveUsarTemaEscuro = Preferencia switch
        {
            PreferenciaTema.Escuro => true,
            PreferenciaTema.Claro => false,
            _ => SistemaUsaTemaEscuro()
        };

        if (!forcarAplicacao && EstaEscuro == deveUsarTemaEscuro)
        {
            return;
        }

        EstaEscuro = deveUsarTemaEscuro;
        var recursos = System.Windows.Application.Current.Resources.MergedDictionaries;
        var dicionarioAtual = recursos.SingleOrDefault(item =>
            item.Source is not null &&
            (item.Source.OriginalString.EndsWith(TemaClaro, StringComparison.OrdinalIgnoreCase) ||
             item.Source.OriginalString.EndsWith(TemaEscuro, StringComparison.OrdinalIgnoreCase)));

        if (dicionarioAtual is not null)
        {
            recursos.Remove(dicionarioAtual);
        }

        recursos.Add(new ResourceDictionary
        {
            Source = new Uri(deveUsarTemaEscuro ? TemaEscuro : TemaClaro, UriKind.Relative)
        });

        TemaAlterado?.Invoke(this, EventArgs.Empty);
    }

    private static bool SistemaUsaTemaEscuro()
    {
        if (!OperatingSystem.IsWindows())
        {
            return false;
        }

        object? valorTema = Registry.GetValue(ChaveTemaWindows, NomeValorTemaWindows, defaultValue: 1);

        return valorTema is int { } valor && valor == 0;
    }
}
