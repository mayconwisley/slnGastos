using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gastos.Infrastructure.Persistence.Configurations;

internal static class PersistenceValueConverters
{
    internal static readonly ValueConverter<DateOnly, DateTime> DateOnlyConverter = new(
        value => value.ToDateTime(TimeOnly.MinValue),
        value => DateOnly.FromDateTime(value));

    internal static readonly ValueConverter<DateOnly?, DateTime?> NullableDateOnlyConverter = new(
        value => value.HasValue ? value.Value.ToDateTime(TimeOnly.MinValue) : null,
        value => value.HasValue ? DateOnly.FromDateTime(value.Value) : null);
}
