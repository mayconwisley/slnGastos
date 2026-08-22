using Gastos.Application.Abstractions;

namespace Gastos.Infrastructure;

public sealed class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}
