using CleanArchitecture.Prover.Application;

namespace CleanArchitecture.Prover.Infrastructure.Providers;

internal class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset Now()
    {
        return DateTimeOffset.Now;
    }
}