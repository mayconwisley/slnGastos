using Microsoft.EntityFrameworkCore;

namespace Gastos.Infrastructure.Persistence;

public sealed class DatabaseInitializer(IDbContextFactory<GastosDbContext> contextFactory)
{
    private const string ModernSchemaMigration = "202608210006_CreateModernSchema";
    private static readonly string[] MigrationsPreModernizacao =
    [
        "202608210001_InitialSchema",
        "202608210002_MigrateLegacyCliente",
        "202608210003_AddCompetenciaIndexes",
        "202608210004_AddMovimentoDevedoresIndex",
        "202608210005_AddUsuarioSchema"
    ];

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        await using var context = await contextFactory.CreateDbContextAsync(cancellationToken);

        var existeCliente = await ExisteTabelaAsync(context, "Cliente", cancellationToken);
        var possuiSchemaModerno = await PossuiSchemaModernoAsync(context, cancellationToken);

        if (existeCliente && !possuiSchemaModerno)
        {
            await PrepararBancoExistenteAsync(context, cancellationToken);
        }
        else if (!existeCliente)
        {
            await PrepararBancoNovoAsync(context, cancellationToken);
        }

        await context.Database.MigrateAsync(cancellationToken);
    }

    private static async Task<bool> ExisteTabelaAsync(
        GastosDbContext context,
        string tableName,
        CancellationToken cancellationToken)
    {
        return await ExecutarEscalarAsync<long>(
            context,
            $"SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = '{tableName}';",
            cancellationToken) > 0;
    }

    private static async Task<bool> PossuiSchemaModernoAsync(
        GastosDbContext context,
        CancellationToken cancellationToken)
    {
        if (!await ExisteTabelaAsync(context, "__EFMigrationsHistory", cancellationToken))
        {
            return false;
        }

        return await ExecutarEscalarAsync<long>(
            context,
            $"SELECT COUNT(*) FROM __EFMigrationsHistory WHERE MigrationId = '{ModernSchemaMigration}';",
            cancellationToken) > 0;
    }

    private static async Task PrepararBancoExistenteAsync(
        GastosDbContext context,
        CancellationToken cancellationToken)
    {
        var colunas = await ObterColunasClienteAsync(context, cancellationToken);

        if (!colunas.Contains("Ativo"))
        {
            await ExecutarAsync(
                context,
                "ALTER TABLE Cliente ADD COLUMN Ativo TEXT NOT NULL DEFAULT 'Sim';",
                cancellationToken);
        }

        if (!colunas.Contains("DataCadastro"))
        {
            await ExecutarAsync(
                context,
                "ALTER TABLE Cliente ADD COLUMN DataCadastro TEXT NULL;",
                cancellationToken);
        }

        var expressaoDataCadastro = colunas.Contains("Data") ? "Data" : "CURRENT_TIMESTAMP";
        await ExecutarAsync(
            context,
            $"UPDATE Cliente SET DataCadastro = {expressaoDataCadastro} WHERE DataCadastro IS NULL;",
            cancellationToken);

        if (colunas.Contains("Data"))
        {
            await ExecutarAsync(
                context,
                """
                CREATE TRIGGER IF NOT EXISTS Cliente_SincronizarDataCadastro
                AFTER INSERT ON Cliente
                FOR EACH ROW
                WHEN NEW.DataCadastro IS NULL
                BEGIN
                    UPDATE Cliente SET DataCadastro = NEW.Data WHERE Id = NEW.Id;
                END;
                """,
                cancellationToken);
        }

        await ExecutarAsync(
            context,
            """
            CREATE TABLE IF NOT EXISTS __EFMigrationsHistory (
                MigrationId TEXT NOT NULL CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY,
                ProductVersion TEXT NOT NULL);
            """,
            cancellationToken);

        await RegistrarMigracoesAsync(context, MigrationsPreModernizacao.Take(2), cancellationToken);
    }

    private static async Task PrepararBancoNovoAsync(
        GastosDbContext context,
        CancellationToken cancellationToken)
    {
        await ExecutarAsync(
            context,
            """
            CREATE TABLE IF NOT EXISTS __EFMigrationsHistory (
                MigrationId TEXT NOT NULL CONSTRAINT PK___EFMigrationsHistory PRIMARY KEY,
                ProductVersion TEXT NOT NULL);
            """,
            cancellationToken);

        await RegistrarMigracoesAsync(context, MigrationsPreModernizacao, cancellationToken);
    }

    private static async Task<HashSet<string>> ObterColunasClienteAsync(
        GastosDbContext context,
        CancellationToken cancellationToken)
    {
        var connection = context.Database.GetDbConnection();
        await connection.OpenAsync(cancellationToken);

        try
        {
            await using var command = connection.CreateCommand();
            command.CommandText = "PRAGMA table_info('Cliente');";
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);

            var colunas = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            while (await reader.ReadAsync(cancellationToken))
            {
                colunas.Add(reader.GetString(reader.GetOrdinal("name")));
            }

            return colunas;
        }
        finally
        {
            await connection.CloseAsync();
        }
    }

    private static async Task RegistrarMigracoesAsync(
        GastosDbContext context,
        IEnumerable<string> migrationIds,
        CancellationToken cancellationToken)
    {
        foreach (var migrationId in migrationIds)
        {
            await RegistrarMigracaoAsync(context, migrationId, cancellationToken);
        }
    }

    private static async Task RegistrarMigracaoAsync(
        GastosDbContext context,
        string migrationId,
        CancellationToken cancellationToken)
    {
        var connection = context.Database.GetDbConnection();
        await connection.OpenAsync(cancellationToken);

        try
        {
            await using var command = connection.CreateCommand();
            command.CommandText =
                "INSERT OR IGNORE INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES ($migrationId, $productVersion);";

            var migrationParameter = command.CreateParameter();
            migrationParameter.ParameterName = "$migrationId";
            migrationParameter.Value = migrationId;
            command.Parameters.Add(migrationParameter);

            var versionParameter = command.CreateParameter();
            versionParameter.ParameterName = "$productVersion";
            versionParameter.Value = "10.0.0";
            command.Parameters.Add(versionParameter);

            await command.ExecuteNonQueryAsync(cancellationToken);
        }
        finally
        {
            await connection.CloseAsync();
        }
    }

    private static async Task<T> ExecutarEscalarAsync<T>(
        GastosDbContext context,
        string sql,
        CancellationToken cancellationToken)
    {
        var connection = context.Database.GetDbConnection();
        await connection.OpenAsync(cancellationToken);

        try
        {
            await using var command = connection.CreateCommand();
            command.CommandText = sql;
            var resultado = await command.ExecuteScalarAsync(cancellationToken)
                ?? throw new InvalidOperationException("A consulta de inicialização do banco não retornou resultado.");

            return (T)Convert.ChangeType(resultado, typeof(T));
        }
        finally
        {
            await connection.CloseAsync();
        }
    }

    private static Task ExecutarAsync(
        GastosDbContext context,
        string sql,
        CancellationToken cancellationToken) =>
        context.Database.ExecuteSqlRawAsync(sql, cancellationToken);
}
