using System.Windows;

namespace Gastos.Presentation.Views;

public partial class SplashWindow : Window
{
    public SplashWindow()
    {
        InitializeComponent();
    }

    public void AtualizarStatus(string status)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(status);
        StatusTextBlock.Text = status;
    }
}
