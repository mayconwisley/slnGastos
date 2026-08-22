using System.Windows;
using System.Windows.Controls;
using Gastos.Presentation.ViewModels;

namespace Gastos.Presentation.Views;

public partial class CadastroInicialUsuarioWindow : Window
{
    private readonly CadastroInicialUsuarioViewModel viewModel;

    public CadastroInicialUsuarioWindow(CadastroInicialUsuarioViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        DataContext = viewModel;
        viewModel.UsuarioCriado += AoCriarUsuario;
    }

    private void AoCriarUsuario(object? sender, EventArgs e)
    {
        DialogResult = true;
    }

    private void SenhaAlterada(object sender, RoutedEventArgs e) => viewModel.Senha = ((PasswordBox)sender).Password;
    private void ConfirmacaoSenhaAlterada(object sender, RoutedEventArgs e) => viewModel.ConfirmacaoSenha = ((PasswordBox)sender).Password;
}
