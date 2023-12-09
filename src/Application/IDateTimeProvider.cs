namespace CleanArchitecture.Prover.Application;

public interface IDateTimeProvider
{
    DateTimeOffset Now();
}