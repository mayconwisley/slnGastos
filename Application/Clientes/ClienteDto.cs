namespace Gastos.Application.Clientes;

public sealed record ClienteDto(int Id, string Nome, string Login, bool Ativo, DateTime DataCadastroUtc);
