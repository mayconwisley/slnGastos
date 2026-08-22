namespace Gastos.Infrastructure.Persistence;

public static class LocalDatabase
{
    private static readonly object SyncRoot = new();

    public static string EnsureCreated()
    {
        lock (SyncRoot)
        {
            var diretorioDados = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Gastos");
            var caminhoBanco = Path.Combine(diretorioDados, "gastos.db");
            if (File.Exists(caminhoBanco))
            {
                return caminhoBanco;
            }

            Directory.CreateDirectory(diretorioDados);
            using (File.Create(caminhoBanco))
            {
            }

            return caminhoBanco;
        }
    }
}
