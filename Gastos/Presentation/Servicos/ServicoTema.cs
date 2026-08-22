using System.Windows;

namespace Gastos.Presentation.Servicos;

public sealed class ServicoTema
{
    private const string TemaClaro = "Themes/Theme.Light.xaml";
    private const string TemaEscuro = "Themes/Theme.Dark.xaml";

    public bool EstaEscuro { get; private set; }

    public void Alternar()
    {
        EstaEscuro = !EstaEscuro;
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
            Source = new Uri(EstaEscuro ? TemaEscuro : TemaClaro, UriKind.Relative)
        });
    }
}
