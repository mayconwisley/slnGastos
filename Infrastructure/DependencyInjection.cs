using Gastos.Application.Abstractions;
using Gastos.Application.Clientes;
using Gastos.Application.Competencias;
using Gastos.Application.DespesasFixas;
using Gastos.Application.Emprestimos;
using Gastos.Application.Devedores;
using Gastos.Application.Movimentacoes;
using Gastos.Application.Seguranca;
using Gastos.Application.Painel;
using Gastos.Application.Usuarios;
using Gastos.Infrastructure.Persistence;
using Gastos.Infrastructure.Seguranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Gastos.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);

        services.AddDbContextFactory<GastosDbContext>(options => options.UseSqlite(connectionString));
        services.AddSingleton<IClienteRepository, ClienteRepository>();
        services.AddSingleton<IClienteReadRepository, ClienteReadRepository>();
        services.AddSingleton<ICompetenciaRepository, CompetenciaRepository>();
        services.AddSingleton<ICompetenciaReadRepository, CompetenciaReadRepository>();
        services.AddSingleton<IDespesaFixaRepository, DespesaFixaRepository>();
        services.AddSingleton<IDespesaFixaReadRepository, DespesaFixaReadRepository>();
        services.AddSingleton<IEmprestimoRepository, EmprestimoRepository>();
        services.AddSingleton<IEmprestimoReadRepository, EmprestimoReadRepository>();
        services.AddSingleton<IParcelaEmprestimoRepository, ParcelaEmprestimoRepository>();
        services.AddSingleton<IDevedorRepository, DevedorRepository>();
        services.AddSingleton<IDevedorReadRepository, DevedorReadRepository>();
        services.AddSingleton<IParcelaDevedorRepository, ParcelaDevedorRepository>();
        services.AddSingleton<IMovimentacaoRepository, MovimentacaoRepository>();
        services.AddSingleton<IMovimentacaoReadRepository, MovimentacaoReadRepository>();
        services.AddSingleton<IResumoPainelReadRepository, ResumoPainelReadRepository>();
        services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
        services.AddSingleton<IPasswordCompatibilityVerifier, PasswordCompatibilityVerifier>();
        services.AddSingleton<IPasswordHasher, Pbkdf2PasswordHasher>();
        services.AddSingleton<IClock, SystemClock>();
        services.AddSingleton<DatabaseInitializer>();

        return services;
    }
}
