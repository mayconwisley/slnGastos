using Gastos.Presentation.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Gastos.Presentation.Servicos;

public sealed class FabricaPagina(IServiceProvider services)
{
    public ObservableObject Criar(RotaPagina rota)
    {
        return rota switch
        {
            RotaPagina.Painel => services.GetRequiredService<PainelViewModel>(),
            RotaPagina.Clientes => services.GetRequiredService<ClientesViewModel>(),
            RotaPagina.Competencias => services.GetRequiredService<CompetenciasViewModel>(),
            RotaPagina.Usuarios => services.GetRequiredService<UsuariosViewModel>(),
            RotaPagina.DespesasFixasCadastro => services.GetRequiredService<DespesasFixasViewModel>(),
            RotaPagina.DespesasFixasConsulta => services.GetRequiredService<ConsultaDespesasFixasViewModel>(),
            RotaPagina.MovimentacoesCadastro => services.GetRequiredService<MovimentacoesViewModel>(),
            RotaPagina.MovimentacoesConsulta => services.GetRequiredService<ConsultaMovimentacoesViewModel>(),
            RotaPagina.EmprestimosCadastro => services.GetRequiredService<EmprestimosViewModel>(),
            RotaPagina.EmprestimosConsulta => services.GetRequiredService<ConsultaEmprestimosViewModel>(),
            RotaPagina.DevedoresCadastro => services.GetRequiredService<DevedoresViewModel>(),
            RotaPagina.DevedoresConsulta => services.GetRequiredService<ConsultaDevedoresViewModel>(),
            RotaPagina.EmprestimosMovimentacao => services.GetRequiredService<ParcelasEmprestimoViewModel>(),
            RotaPagina.DevedoresMovimentacao => services.GetRequiredService<ParcelasDevedorViewModel>(),
            _ => throw new ArgumentOutOfRangeException(nameof(rota), rota, "Rota de página não suportada.")
        };
    }
}
