using Gastos.Application.Usuarios;
using Gastos.Domain.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class UsuarioRepository(IDbContextFactory<GastosDbContext> factory) : IUsuarioRepository
{
    public async Task AdicionarAsync(Usuario usuario, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        await context.Usuarios.AddAsync(usuario, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task<Usuario?> ObterPorLoginAsync(string login, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        return await context.Usuarios.SingleOrDefaultAsync(item => item.Login == login, ct);
    }

    public async Task AtualizarAsync(Usuario usuario, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        context.Usuarios.Update(usuario);
        await context.SaveChangesAsync(ct);
    }

    public async Task RemoverAsync(Usuario usuario, CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        context.Usuarios.Remove(usuario);
        await context.SaveChangesAsync(ct);
    }

    public async Task<IReadOnlyList<UsuarioDto>> ListarAsync(CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        return await context.Usuarios.AsNoTracking()
            .OrderBy(item => item.Nome)
            .Select(item => new UsuarioDto(item.Login, item.Nome, item.Lembrete, item.Ativo, item.DataCadastroUtc))
            .ToListAsync(ct);
    }

    public async Task<int> ContarAsync(CancellationToken ct)
    {
        await using var context = await factory.CreateDbContextAsync(ct);
        return await context.Usuarios.CountAsync(ct);
    }
}
