using Gastos.Domain.Clientes;
using Gastos.Domain.Competencias;
using Gastos.Domain.DespesasFixas;
using Gastos.Domain.Devedores;
using Gastos.Domain.Emprestimos;
using Gastos.Domain.Movimentacoes;
using Gastos.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class GastosDbContext(DbContextOptions<GastosDbContext> options) : DbContext(options)
{
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Competencia> Competencias => Set<Competencia>();
    public DbSet<DespesaFixa> DespesasFixas => Set<DespesaFixa>();
    public DbSet<Emprestimo> Emprestimos => Set<Emprestimo>();
    public DbSet<ParcelaEmprestimo> ParcelasEmprestimos => Set<ParcelaEmprestimo>();
    public DbSet<Devedor> Devedores => Set<Devedor>();
    public DbSet<ParcelaDevedor> ParcelasDevedores => Set<ParcelaDevedor>();
    public DbSet<Movimentacao> Movimentacoes => Set<Movimentacao>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GastosDbContext).Assembly);
    }
}
