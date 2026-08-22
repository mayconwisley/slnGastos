using System.Windows;
using Gastos.Presentation.ViewModels;

namespace Gastos.Presentation.Views;

public partial class MainWindow : Window
{
    private readonly ShellViewModel viewModel;

    public MainWindow(ShellViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        DataContext = viewModel;
        Loaded += AoCarregar;
    }

    private async void AoCarregar(object sender, RoutedEventArgs e)
    {
        Loaded -= AoCarregar;
        await viewModel.InicializarAsync();
    }
}
