using System.Windows;
using System.Windows.Controls;
using Gastos.Presentation.ViewModels;

namespace Gastos.Presentation.Views;

public partial class UsuariosPage : UserControl
{
    public UsuariosPage()
    {
        InitializeComponent();
        DataContextChanged += AoAlterarDataContext;
    }

    private void AoAlterarDataContext(object sender, DependencyPropertyChangedEventArgs e)
    {
        Senha.Password = string.Empty;
        ConfirmarSenha.Password = string.Empty;
    }

    private void SenhaAlterada(object sender, RoutedEventArgs e)
    {
        if (DataContext is UsuariosViewModel viewModel)
        {
            viewModel.Senha = ((PasswordBox)sender).Password;
        }
    }

    private void ConfirmarSenhaAlterada(object sender, RoutedEventArgs e)
    {
        if (DataContext is UsuariosViewModel viewModel)
        {
            viewModel.ConfirmarSenha = ((PasswordBox)sender).Password;
        }
    }

    private void AoSelecionarUsuario(object sender, SelectionChangedEventArgs e)
    {
        Senha.Password = string.Empty;
        ConfirmarSenha.Password = string.Empty;
    }
}
