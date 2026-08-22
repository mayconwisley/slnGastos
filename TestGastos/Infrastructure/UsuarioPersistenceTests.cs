using Gastos.Application.Abstractions;
using Gastos.Application.Usuarios;
using Gastos.Infrastructure.Persistence;
using Gastos.Infrastructure.Seguranca;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestGastos.Infrastructure;

public sealed class UsuarioPersistenceTests
{
    [Test]
    public void Verificar_CredencialNoFormatoExistente_DevePermitirAcesso()
    {
        const string chave = "chave-legada";
        const string senha = "senha-segura";
        var senhaCriptografada = CriptografarNoFormatoExistente(chave, senha);
        var verifier = new PasswordCompatibilityVerifier();

        Assert.That(verifier.Verificar(senha, senhaCriptografada, chave), Is.True);
        Assert.That(verifier.Verificar("outra-senha", senhaCriptografada, chave), Is.False);
    }

    [Test]
    public async Task CadastrarEAutenticar_ComSenhaPbkdf2_DevePermitirAcesso()
    {
        var caminho = Path.Combine(Path.GetTempPath(), $"gastos-usuario-{Guid.NewGuid():N}.db");
        var options = new DbContextOptionsBuilder<GastosDbContext>().UseSqlite($"Data Source={caminho}").Options;

        try
        {
            await using (var context = new GastosDbContext(options))
            {
                await context.Database.EnsureCreatedAsync();
            }

            var repository = new UsuarioRepository(new FactoryFake(options));
            var hash = new Pbkdf2PasswordHasher();
            var cadastrar = new CadastrarUsuarioHandler(repository, hash, new ClockFake());
            var autenticar = new AutenticarUsuarioHandler(repository, hash, new PasswordCompatibilityVerifier());

            var cadastro = await cadastrar.HandleAsync(new CadastrarUsuarioCommand("maycon", "Maycon", "senha-segura", "Lembrete", true), CancellationToken.None);
            var acesso = await autenticar.HandleAsync(new AutenticarUsuarioCommand("maycon", "senha-segura"), CancellationToken.None);
            var acessoNegado = await autenticar.HandleAsync(new AutenticarUsuarioCommand("maycon", "senha-incorreta"), CancellationToken.None);

            Assert.That(cadastro.IsSuccess, Is.True);
            Assert.That(acesso.IsSuccess, Is.True);
            Assert.That(acessoNegado.IsSuccess, Is.False);
        }
        finally
        {
            SqliteConnection.ClearAllPools();
            if (File.Exists(caminho)) File.Delete(caminho);
        }
    }

    private sealed class ClockFake : IClock
    {
        public DateTime UtcNow => new(2026, 8, 1, 0, 0, 0, DateTimeKind.Utc);
    }

    private sealed class FactoryFake(DbContextOptions<GastosDbContext> options) : IDbContextFactory<GastosDbContext>
    {
        public GastosDbContext CreateDbContext() => new(options);
        public Task<GastosDbContext> CreateDbContextAsync(CancellationToken cancellationToken = default) => Task.FromResult(CreateDbContext());
    }

    private static string CriptografarNoFormatoExistente(string chave, string senha)
    {
        using var aes = System.Security.Cryptography.Aes.Create();
        using var sha256 = System.Security.Cryptography.SHA256.Create();

        aes.Key = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(chave));
        aes.Mode = System.Security.Cryptography.CipherMode.ECB;
        aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;

        var bytesSenha = System.Text.Encoding.UTF8.GetBytes(senha);
        var encryptor = aes.CreateEncryptor();
        var bytesCriptografados = encryptor.TransformFinalBlock(bytesSenha, 0, bytesSenha.Length);

        return Convert.ToBase64String(bytesCriptografados);
    }
}
