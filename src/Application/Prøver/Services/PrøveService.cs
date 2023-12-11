using CleanArchitecture.Prover.Domain.Entities;
using CleanArchitecture.Prover.Domain.ValueTypes;

namespace CleanArchitecture.Prover.Application.Prøver.Services;

internal class PrøveService(IPrøveRepository prøveRepository, IDateTimeProvider dateTimeProvider) : IPrøveService
{
    public Task<IEnumerable<Prøve>> GetAllAsync()
    {
        return prøveRepository.GetAllAsync();
    }

    public Task<Prøve> GetByIdAsync(PrøveId prøveId)
    {
        return prøveRepository.GetByIdAsync(prøveId);
    }

    public async Task<Prøve> CreateAsync(PrøveNavn navn, Trinn trinn, Fag fag, PrøvePeriode prøvePeriode)
    {
        if (prøvePeriode.Start <= dateTimeProvider.Now())
        {
            throw new ArgumentException("Start of PrøvePeriode has to be in the future",nameof(prøvePeriode));
        }
        var createdProve = await prøveRepository.CreateAsync(navn, trinn, fag, prøvePeriode);
        return createdProve;
    }
}