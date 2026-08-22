using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Gastos.Presentation.ViewModels;

namespace Gastos.Presentation.Views;

public partial class LoginWindow : Window
{
    private readonly LoginViewModel viewModel;

    public LoginWindow(LoginViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        DataContext = viewModel;
        viewModel.Autenticado += AoAutenticar;
    }

    private void AoAutenticar(object? sender, EventArgs e)
    {
        DialogResult = true;
    }

    private void SenhaLoginAlterada(object sender, RoutedEventArgs e) => viewModel.Senha = ((PasswordBox)sender).Password;

    private void SenhaLoginTeclaPressionada(object sender, KeyEventArgs e)
    {
        if (e.Key != Key.Enter || !viewModel.EntrarCommand.CanExecute(null))
        {
            return;
        }

        viewModel.EntrarCommand.Execute(null);
        e.Handled = true;
    }
}
