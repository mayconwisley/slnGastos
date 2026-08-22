namespace Gastos.Application.Competencias;

public sealed record CompetenciaDto(int Id, DateOnly MesReferencia, int ClienteId, bool Ativa);
