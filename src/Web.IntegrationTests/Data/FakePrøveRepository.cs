using CleanArchitecture.Prover.Application.Prøver;
using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace Web.IntegrationTests.Data;

internal class FakePrøveRepository : IPrøveRepository
{
    public static int ExistingPrøveId = 42;
    public static readonly DateTimeOffset Today = new(new DateTime(2023, 12, 05));
    private readonly IEnumerable<Prøve> _prøver = new List<Prøve>
    {
        new(
            new PrøveId(ExistingPrøveId),
            new PrøveNavn("En eksisterende prøve"),
            new PrøvePeriode(Today.AddDays(1), Today.AddDays(10)),
            new Trinn(5),
            Fag.Matematikk)
    };

    public Task<IEnumerable<Prøve>> GetAllAsync()
    {
        return Task.FromResult(_prøver);
    }

    public Task<Prøve> GetByIdAsync(PrøveId prøveId)
    {
        return Task.FromResult(_prøver.First(p => p.Id == prøveId));
    }
}