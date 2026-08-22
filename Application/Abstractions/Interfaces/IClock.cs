namespace Gastos.Application.Abstractions;

public interface IClock
{
    DateTime UtcNow { get; }
}
