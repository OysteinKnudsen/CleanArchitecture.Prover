using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøver.Services;

internal class PrøveService(IPrøveRepository prøveRepository, IDateTimeProvider dateTimeProvider) : IPrøveService
{
    public Task<IEnumerable<Prøve>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Prøve> GetByIdAsync(PrøveId prøveId)
    {
        throw new NotImplementedException();
    }

    public async Task<Prøve> CreateAsync(PrøveNavn navn, Trinn trinn, Fag fag, PrøvePeriode prøvePeriode)
    {
        throw new NotImplementedException();
    }
}